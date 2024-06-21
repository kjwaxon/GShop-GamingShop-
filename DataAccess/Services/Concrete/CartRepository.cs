using ApplicationCore.DTO_s.CheckoutDTO;
using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.UserEntities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public CartRepository(AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public async Task<int> AddItem(int productId, int quantity)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not logged-in");

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var cart = await GetOrCreateCartAsync(userId);
                var cartItem = await _context.CartDetails
                                              .FirstOrDefaultAsync(a => a.CartId == cart.Id && a.ProductId == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    var product = await _context.Products.FindAsync(productId);
                    if (product == null)
                        throw new InvalidOperationException("Product not found");

                    cartItem = new CartDetail
                    {
                        ProductId = productId,
                        CartId = cart.Id,
                        Quantity = quantity,
                        UnitPrice = product.UnitPrice
                    };
                    _context.CartDetails.Add(cartItem);
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return await GetCartCount(userId);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task RemoveItem(int productId)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not logged-in");

            var cart = await GetCartByUserId(userId);
            if (cart == null)
                throw new InvalidOperationException("Cart not found");

            var cartItem = await _context.CartDetails
                                          .FirstOrDefaultAsync(a => a.CartId == cart.Id && a.ProductId == productId);

            if (cartItem != null)
            {
                _context.CartDetails.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateQuantity(int productId, int change)
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not logged-in");

            var cart = await GetCartByUserId(userId);
            if (cart == null)
                throw new InvalidOperationException("Cart not found");

            var cartItem = await _context.CartDetails
                                          .FirstOrDefaultAsync(a => a.CartId == cart.Id && a.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += change;
                if (cartItem.Quantity <= 0)
                {
                    _context.CartDetails.Remove(cartItem);
                }
                else
                {
                    _context.CartDetails.Update(cartItem);
                }
                await _context.SaveChangesAsync();
            }
        }





        public async Task<Cart> GetCart()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                throw new InvalidOperationException("Invalid userId");

            return await _context.Carts
                .Include(a => a.CartDetails)
                    .ThenInclude(a => a.Product)
                        .ThenInclude(p => p.Stock)
                .Include(a => a.CartDetails)
                    .ThenInclude(a => a.Product)
                        .ThenInclude(p => p.Subcategory)
                .FirstOrDefaultAsync(a => a.UserId == userId);
        }



        public async Task<Cart> GetCartByUserId(string userId)
        {
            return await _context.Carts.Include(c => c.CartDetails).FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<int> GetCartCount(string userId = "")
        {
            userId = string.IsNullOrEmpty(userId) ? GetUserId() : userId;
            var cartCount = await _context.CartDetails
                .Where(cd => cd.Cart.UserId == userId)
                .SumAsync(cd => cd.Quantity);

            _session.SetInt32("CartCount", cartCount);
            return cartCount;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> Checkout(CheckoutDTO model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException("User is not logged-in");

                var cart = await GetCartByUserId(userId);
                if (cart == null || !cart.CartDetails.Any())
                    throw new InvalidOperationException("Cart is empty or invalid");

                var pendingRecord = await _context.OrderStatuses.FirstOrDefaultAsync(s => s.StatusName == "Pending");
                if (pendingRecord == null)
                    throw new InvalidOperationException("Order status does not have Pending status. Please contact support.");

                var order = new Order
                {
                    UserId = userId,
                    Name = model.Name,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber,
                    PaymentMethod = model.PaymentMethod,
                    Address = model.Address,
                    IsPaid = false,
                    OrderStatusId = pendingRecord.Id
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                var cartDetail = await _context.CartDetails
                                   .Where(a => a.CartId == cart.Id).ToListAsync();
                foreach (var item in cartDetail)
                {
                    var orderDetail = new OrderDetail
                    {
                        ProductId = item.ProductId,
                        OrderId = order.Id,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };
                    _context.OrderDetails.Add(orderDetail);

                    var stock = await _context.Stocks.FirstOrDefaultAsync(a => a.ProductId == item.ProductId);
                    if (stock == null || item.Quantity > stock.Quantity)
                        throw new InvalidOperationException($"Only {stock?.Quantity ?? 0} item(s) are available in the stock");

                    stock.Quantity -= item.Quantity;
                }
                _context.CartDetails.RemoveRange(cartDetail);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (false, GetInnermostExceptionMessage(ex));
            }
        }

        private string GetInnermostExceptionMessage(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex.Message;
        }


        public async Task<bool> ClearCart(string userId)
        {
            var cart = await GetCartByUserId(userId);
            if (cart == null) return false;

            _context.CartDetails.RemoveRange(cart.CartDetails);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> GetCartTotal(string userId)
        {
            var cart = await GetCartByUserId(userId);
            return cart?.CartDetails.Sum(x => x.Quantity * (decimal)x.Product.UnitPrice) ?? 0;
        }

        public async Task<bool> RemoveItemFromCart(string userId, int productId)
        {
            var cart = await GetCartByUserId(userId);
            if (cart == null) return false;

            var cartDetail = cart.CartDetails.FirstOrDefault(x => x.ProductId == productId);
            if (cartDetail == null) return false;

            _context.CartDetails.Remove(cartDetail);
            await _context.SaveChangesAsync();
            return true;
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext?.User;
            return _userManager.GetUserId(principal);
        }
        public async Task<bool> ItemExistsInCart(int productId)
        {
            return await _context.CartDetails.AnyAsync(x => x.ProductId == productId);
        }
        private async Task<Cart> CreateCartAsync(string userId)
        {
            var cart = new Cart { UserId = userId };
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
        private async Task<Cart> GetOrCreateCartAsync(string userId)
        {
            var cart = await GetCartByUserId(userId);
            if (cart == null)
            {
                cart = await CreateCartAsync(userId);
            }
            return cart;
        }

    }
}
