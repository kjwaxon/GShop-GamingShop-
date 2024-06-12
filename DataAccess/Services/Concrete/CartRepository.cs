using ApplicationCore.Entities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        private readonly IProductRepository _productRepo;

        public CartRepository(AppDbContext context, IProductRepository productRepo) : base(context)
        {
            _productRepo = productRepo;
        }

        public async Task<bool> AddItemToCart(string userId, int productId, int quantity)
        {
            var cart = await GetByDefaultAsync(x => x.UserId == userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                await AddAsync(cart);
                await SaveAsync();
            }

            var isAvailable = await _productRepo.IsProductAvailable(productId, quantity);
            if (!isAvailable)
            {
                return false;
            }

            var product = await _productRepo.GetByIdAsync(productId);
            var cartDetail = cart.CartDetails.FirstOrDefault(x => x.ProductId == productId);
            if (cartDetail == null)
            {
                cartDetail = new CartDetail
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity,
                    Product = product
                };
                cart.CartDetails.Add(cartDetail);
            }
            else
            {
                cartDetail.Quantity += quantity;
            }

            return await UpdateAsync(cart);
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cart = await GetByDefaultAsync(x => x.UserId == userId);
            if (cart == null) return false;

            cart.CartDetails.Clear();
            return await UpdateAsync(cart);
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            return await GetByDefaultAsync(x => x.UserId == userId);
        }

        public async Task<decimal> GetCartTotal(string userId)
        {
            var cart = await GetByDefaultAsync(x => x.UserId == userId);
            if (cart == null) return 0;

            return cart.CartDetails.Sum(x => x.Quantity * (decimal)x.Product.UnitPrice);
        }

        public async Task<bool> RemoveItemFromCart(string userId, int productId)
        {
            var cart = await GetByDefaultAsync(x => x.UserId == userId);
            if (cart == null) return false;

            var cartDetail = cart.CartDetails.FirstOrDefault(x => x.ProductId == productId);
            if (cartDetail == null) return false;

            cart.CartDetails.Remove(cartDetail);
            return await UpdateAsync(cart);
        }

        public async Task<bool> UpdateItemQuantity(string userId, int productId, int quantity)
        {
            var cart = await GetByDefaultAsync(x => x.UserId == userId);
            if (cart == null) return false;

            var cartDetail = cart.CartDetails.FirstOrDefault(x => x.ProductId == productId);
            if (cartDetail == null) return false;

            var isAvailable = await _productRepo.IsProductAvailable(productId, quantity);
            if (!isAvailable)
            {
                return false;
            }

            cartDetail.Quantity = quantity;
            return await UpdateAsync(cart);
        }
    }
}
