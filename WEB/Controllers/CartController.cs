using ApplicationCore.DTO_s.CheckoutDTO;
using ApplicationCore.Entities.UserEntities.Concrete;
using DataAccess.Services.Concrete;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public CartController(ICartRepository cartRepo, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _cartRepo = cartRepo;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddItem(int productId, int quantity)
        {
            try
            {
                bool itemExists = await _cartRepo.ItemExistsInCart(productId);
                if (itemExists)
                {
                    TempData["Error"] = "You already have this item in cart. Check the cart to change quantity!";
                }
                else
                {
                    await _cartRepo.AddItem(productId, quantity);
                    TempData["Success"] = "Item added to cart successfully.";
                }
                string userId = _userManager.GetUserId(User);
                int cartCount = await _cartRepo.GetCartCount(userId);
                HttpContext.Session.SetInt32("CartCount", cartCount);
                
                return RedirectToAction("Index", "Home");
            }
            catch (UnauthorizedAccessException)
            {
                TempData["Error"] = "You must be logged in to add items to the cart.";
                return RedirectToAction("Login", "Account");
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["Error"] = "An unexpected error occurred. Please try again later.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int productId)
        {
            try
            {
                await _cartRepo.RemoveItem(productId);
                string userId = _userManager.GetUserId(User);
                int cartCount = await _cartRepo.GetCartCount(userId);
                TempData["Success"] = "Item removed from cart successfully.";
                return RedirectToAction("GetCart");
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while removing the item. Please try again later.";
                return RedirectToAction("GetCart");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int productId, int change)
        {
            try
            {
                await _cartRepo.UpdateQuantity(productId, change);
                string userId = _userManager.GetUserId(User);
                int cartCount = await _cartRepo.GetCartCount(userId);
                TempData["Success"] = "Cart updated successfully.";
                return RedirectToAction("GetCart");
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while updating the item quantity. Please try again later.";
                return RedirectToAction("GetCart");
            }
        }

        public async Task<IActionResult> GetCart()
        {
            var cart = await _cartRepo.GetCart();
            int cartCount = cart?.CartDetails.Sum(cd => cd.Quantity) ?? 0;
            HttpContext.Session.SetInt32("CartCount", cartCount);
            TempData["CartCount"] = cartCount;
            return View(cart);
        }


        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Error"] = "You must be logged in to clear the cart.";
                return RedirectToAction("Login", "Account");
            }

            var result = await _cartRepo.ClearCart(userId);

            if (result)
            {
                HttpContext.Session.SetInt32("CartCount", 0);
                TempData["Success"] = "Cart cleared successfully.";
                TempData["CartCount"] = 0;
            }
            else
            {
                TempData["Error"] = "Failed to clear the cart.";
            }

            return RedirectToAction("GetCart");
        }


        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var (isCheckedOut, errorMessage) = await _cartRepo.Checkout(model);

            if (!isCheckedOut)
            {
                // Optionally, add the error message to the ModelState to show it in the view
                TempData["ErrorMessage"] = errorMessage;
                return RedirectToAction(nameof(OrderFailure));
            }

            return RedirectToAction(nameof(OrderSuccess));
            //if (!ModelState.IsValid)
            //{
            //    TempData["Error"] = "Invalid checkout information.";
            //    return RedirectToAction("GetCart");
            //}

            //try
            //{
            //    var result = await _cartRepo.Checkout(model);

            //    if (result)
            //    {
            //        HttpContext.Session.SetInt32("CartCount", 0);
            //        TempData["Success"] = "Checkout successful.";
            //        TempData["CartCount"] = 0;
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        TempData["Error"] = "Checkout failed. Please try again.";
            //        return RedirectToAction("GetCart");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    TempData["Error"] = $"Checkout failed due to an error: {ex.Message}. Please try again.";
            //    return RedirectToAction("GetCart");
            //}
        }



        public IActionResult OrderSuccess()
        {
            return View();
        }

        public IActionResult OrderFailure()
        {
            return View();
        }
    }
}
