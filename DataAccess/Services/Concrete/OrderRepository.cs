using ApplicationCore.DTO_s.OrderDTO;
using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.UserEntities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public OrderRepository(AppDbContext context,IHttpContextAccessor httpContextAccessor,UserManager<AppUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _context.Orders
                .Include(x => x.OrderStatus)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Subcategory)
                .FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrders(bool getAll = false)
        {
            var ordersQuery = _context.Orders
                .Include(x => x.OrderStatus)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Subcategory)
                .AsQueryable();

            if (!getAll)
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    throw new Exception("User is not logged in");
                }

                ordersQuery = ordersQuery.Where(a => a.UserId == userId);
            }

            return await ordersQuery.ToListAsync();
        }

        public async Task<IEnumerable<OrderStatus>> GetOrderStatuses()
        {
            return await _context.OrderStatuses.ToListAsync();
        }

        public async Task UpdatePaymentStatus(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                Console.WriteLine($"Before Update: IsPaid = {order.IsPaid}");
                _context.Attach(order);
                order.IsPaid = !order.IsPaid;
                _context.Entry(order).State = EntityState.Modified;
                Console.WriteLine($"Entity State Before Save: {_context.Entry(order).State}");
                await _context.SaveChangesAsync();
                Console.WriteLine($"Entity State After Save: {_context.Entry(order).State}");
                Console.WriteLine($"After SaveChanges: IsPaid = {order.IsPaid}");

                await _context.Entry(order).ReloadAsync();
                Console.WriteLine($"After Reload: IsPaid = {order.IsPaid}");
            }
            else
            {
                throw new Exception("Order not found.");
            }
        }

        public async Task UpdateOrderStatus(UpdateOrderDTO model)
        {
            var order = await _context.Orders.FindAsync(model.OrderId);
            if (order != null)
            {
                Console.WriteLine($"Before Update: OrderStatusId = {order.OrderStatusId}");
                _context.Attach(order);
                order.OrderStatusId = model.OrderStatusId;
                _context.Entry(order).State = EntityState.Modified;

                Console.WriteLine($"Entity State Before Save: {_context.Entry(order).State}");
                await _context.SaveChangesAsync();

                Console.WriteLine($"Entity State After Save: {_context.Entry(order).State}");
                Console.WriteLine($"After SaveChanges: OrderStatusId = {order.OrderStatusId}");

                await _context.Entry(order).ReloadAsync();
                Console.WriteLine($"After Reload: OrderStatusId = {order.OrderStatusId}");
            }
            else
            {
                throw new Exception("Order not found.");
            }
        }


        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            return _userManager.GetUserId(principal);
        }
    }
}
