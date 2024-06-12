using ApplicationCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
        Task<bool> AddOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(Order order);
    }
}
