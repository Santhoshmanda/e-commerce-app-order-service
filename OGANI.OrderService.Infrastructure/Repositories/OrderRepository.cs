using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OGANI.OrderService.Domain.Interfaces;
using OGANI.OrderService.Domain.Models;
using OGANI.OrderService.Infrastructure.Enums;
using OGANI.OrderService.Infrastructure.Persistance;
using db_entities = OGANI.OrderService.Infrastructure.Entities;

namespace OGANI.OrderService.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OganiDbContext _oganiDbContext;
        private readonly IMapper _mapper;
        public OrderRepository(OganiDbContext oganiDbContext, IMapper mapper)
		{
            _oganiDbContext = oganiDbContext;
            _mapper = mapper;
		}

        public async Task<bool> CancelOrder(int orderId)
        {
            var orderStatusEntity = _oganiDbContext.OrderStatuses.Find(orderId);
            if (orderStatusEntity != null)
            {
                orderStatusEntity.StatusName = nameof(OrderStatuses.CANCELLED);
                _oganiDbContext.Update(orderStatusEntity);
                await _oganiDbContext.SaveChangesAsync();
                return true;
            }
            return false;
           
        }

        public async Task<Order> CreateOrder(Order order)
        {
            var orderEntity = _mapper.Map<db_entities.Order>(order);
            _oganiDbContext.Add(orderEntity);
            await _oganiDbContext.SaveChangesAsync();
            order.OrderId = orderEntity.OrderId;
            return order;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var order = _oganiDbContext.Orders.Find(orderId);
            if (order != null)
            {
                _oganiDbContext.Remove(order);
                await _oganiDbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<Order?> GetOrderByOrderId(int orderId)
        {
            return await _oganiDbContext.Orders
                .ProjectTo<Order>(_mapper.ConfigurationProvider)
                .Include(o=>o.OrderItems)
                .Include(o=>o.OrderStatuses)
                .Include(o=>o.PaymentInformations)
                .FirstOrDefaultAsync(order=>order.OrderId==orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
            return await _oganiDbContext.Orders
                 .ProjectTo<Order>(_mapper.ConfigurationProvider)
                 .Include(o => o.OrderItems)
                 .Include(o => o.OrderStatuses)
                 .Include(o => o.PaymentInformations)
                 .Where(o => o.UserId == userId)
                 .ToListAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _oganiDbContext.Entry(order).State = EntityState.Modified;
            await _oganiDbContext.SaveChangesAsync();
        }
    }
}

