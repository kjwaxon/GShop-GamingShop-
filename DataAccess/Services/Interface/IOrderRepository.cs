using ApplicationCore.DTO_s.OrderDTO;
using ApplicationCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders(bool getAll=false);
        Task UpdateOrderStatus(UpdateOrderDTO model);
        Task UpdatePaymentStatus(int orderId);
        Task<Order?> GetOrderById(int orderId);
        Task<IEnumerable<OrderStatus>> GetOrderStatuses();
    }
}
