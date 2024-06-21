using ApplicationCore.DTO_s.CheckoutDTO;
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
        Task<int> AddItem(int productId, int quantity);

        Task UpdateQuantity(int productId, int change);
        Task RemoveItem(int productId);
        Task<Cart> GetCart();
        Task<Cart> GetCartByUserId(string userId);
        Task<int> GetCartCount(string userId);
        Task<bool> ItemExistsInCart(int productId);
        Task<bool> ClearCart(string userId); 
        Task<(bool IsSuccess, string ErrorMessage)> Checkout(CheckoutDTO model);

    }
}
