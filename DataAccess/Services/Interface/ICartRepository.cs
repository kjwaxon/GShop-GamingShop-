using ApplicationCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface ICartRepository:IBaseRepository<Cart>
    {
        Task<bool> AddItemToCart(string userId, int productId, int quantity);
        Task<bool> UpdateItemQuantity(string userId, int productId, int quantity);
        Task<bool> RemoveItemFromCart(string userId, int productId);
        Task<Cart> GetCartByUserId(string userId);
        Task<bool> ClearCart(string userId);
        Task<decimal> GetCartTotal(string userId);

    }
}
