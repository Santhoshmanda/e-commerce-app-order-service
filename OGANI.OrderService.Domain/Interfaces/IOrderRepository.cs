using System;
using OGANI.OrderService.Domain.Models;

namespace OGANI.OrderService.Domain.Interfaces
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetOrdersByUserId(int userId);
		Task<Order?> GetOrderByOrderId(int orderId);
		Task<Order> CreateOrder(Order order);
		Task UpdateOrder(Order order);
        Task<bool> CancelOrder(int orderId);
        Task<bool> DeleteOrder(int orderId);
    }
}

