using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _table
                .Include(x => x.OrderDetails)
                .FirstOrDefaultAsync(x => x.Id == orderId && x.Status != Status.Passive);
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _table
                .Include(x => x.OrderDetails)
                .Where(x => x.UserId == userId && x.Status != Status.Passive)
                .ToListAsync();
        }

        public async Task<bool> AddOrderAsync(Order order)
        {
            await _table.AddAsync(order);
            return await SaveAsync();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            
            return await UpdateAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(Order order)
        {
            return await DeleteAsync(order);
        }
    }
}
