using ApplicationCore.DTO_s.OrderDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.UserEntities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.Services.Concrete
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public OrderRepository(AppDbContext context,IHttpContextAccessor httpContextAccessor,UserManager<AppUser> userManager) : base(context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrders(bool getAll = false)
        {
            var orders = _context.Orders
                           .Include(x => x.OrderStatus)
                           .Include(x => x.OrderDetails)
                           .ThenInclude(x => x.Product)
                           .ThenInclude(x => x.Subcategory).AsQueryable();
            if (!getAll)
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("User is not logged-in");
                orders = orders.Where(a => a.UserId == userId);
                return await orders.ToListAsync();
            }

            return await orders.ToListAsync();
        }

        public async Task<IEnumerable<OrderStatus>> GetOrderStatuses()
        {
            return await _context.OrderStatuses.ToListAsync();
        }

        public async Task PaymentStatus(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order is null)
            {
                throw new InvalidOperationException($"Order id:{orderId} is not found!");
            }
            order.IsPaid=!order.IsPaid;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderStatus(UpdateOrderDTO model)
        {
            var order = await _context.Orders.FindAsync(model.OrderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order id:{model.OrderId} is not found");
            }
            order.OrderStatusId = model.OrderStatusId;
            await _context.SaveChangesAsync();
        }
        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }
    }
}
