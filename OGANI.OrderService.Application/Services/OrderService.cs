using System;
using OGANI.OrderService.Domain.Interfaces;
using OGANI.OrderService.Domain.Models;

namespace OGANI.OrderService.Application.Services
{
	public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
		public OrderService(IOrderRepository orderRepository)
		{
            _orderRepository = orderRepository;
		}

        public async Task<bool> CancelOrder(int orderId)
        {
            return await _orderRepository.CancelOrder(orderId);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderRepository.CreateOrder(order);
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            return await _orderRepository.DeleteOrder(orderId);
        }

        public async Task<Order?> GetOrderByOrderId(int orderId)
        {
            return await _orderRepository.GetOrderByOrderId(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
            return await _orderRepository.GetOrdersByUserId(userId);
        }

        public async Task UpdateOrder(Order order)
        {
             await _orderRepository.UpdateOrder(order);
        }
    }
}

