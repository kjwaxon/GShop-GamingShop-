using ApplicationCore.Entities.Concrete;
using AutoMapper;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WEB.Models.ViewModels;

namespace WEB.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepo;
        private readonly IUserRepository _userRepo;
        private readonly IOrderRepository _orderRepo;

        public CartController(ICartRepository cartRepo, IUserRepository userRepo, IOrderRepository orderRepo)
        {
            _cartRepo = cartRepo;
            _userRepo = userRepo;
            _orderRepo = orderRepo;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            var cart = await _cartRepo.GetCartByUserId(user.Id);
            if (cart == null || cart.CartDetails == null || cart.CartDetails.Count == 0)
            {
                var emptyCartVM = new GetCartVM { BuyerId = user.Id };
                return View(emptyCartVM);
            }

            var cartItems = cart.CartDetails.Select(x => new CartItemVM
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.Product.ProductName,
                UnitPrice = x.Product.UnitPrice,
                Quantity = x.Quantity,
                ImageUrl = x.Product.ImagePath
            }).ToList();

            var cartVM = new GetCartVM
            {
                Id = cart.Id,
                BuyerId = cart.UserId,
                cartItems = cartItems
            };
            return View(cartVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCart(int productId, int quantity)
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            var result = await _cartRepo.AddItemToCart(user.Id, productId, quantity);
            if (result)
            {
                TempData["Success"] = "Item added to cart!";
            }
            else
            {
                TempData["Error"] = "Item could not be added to cart!";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateItemQuantity(int productId, int quantity)
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            var result = await _cartRepo.UpdateItemQuantity(user.Id, productId, quantity);
            if (result)
            {
                TempData["Success"] = "Item quantity updated!";
            }
            else
            {
                TempData["Error"] = "Item quantity could not be updated!";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItemFromCart(int productId)
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            var result = await _cartRepo.RemoveItemFromCart(user.Id, productId);
            if (result)
            {
                TempData["Success"] = "Item removed from cart!";
            }
            else
            {
                TempData["Error"] = "Item could not be removed from cart!";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            var result = await _cartRepo.ClearCart(user.Id);
            if (result)
            {
                TempData["Success"] = "Cart cleared!";
            }
            else
            {
                TempData["Error"] = "Cart could not be cleared!";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            var cart = await _cartRepo.GetCartByUserId(user.Id);
            if (cart == null || cart.CartDetails == null || cart.CartDetails.Count == 0)
            {
                return RedirectToAction("Index");
            }

            var cartItems = cart.CartDetails.Select(x => new CartItemVM
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.Product.ProductName,
                UnitPrice = x.Product.UnitPrice,
                Quantity = x.Quantity,
                ImageUrl = x.Product.ImagePath
            }).ToList();

            var checkoutVM = new CheckoutVM
            {
                BuyerId = cart.UserId,
                CartItems = cartItems,
                TotalAmount = (decimal)cartItems.Sum(x => x.UnitPrice * x.Quantity)
            };

            return View(checkoutVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userRepo.FindUser(HttpContext.User);
            var cart = await _cartRepo.GetCartByUserId(user.Id);

            if (cart == null || cart.CartDetails == null || cart.CartDetails.Count == 0)
            {
                return RedirectToAction("Index");
            }

            var order = new Order
            {
                UserId = user.Id,
                TotalAmount = model.TotalAmount,
                PaymentStatus = "Pending",
                OrderDetails = cart.CartDetails.Select(x => new OrderDetail
                {
                    ProductName = x.Product.ProductName,
                    UnitPrice = x.Product.UnitPrice,
                    ImagePath = x.Product.ImagePath,
                    Quantity = x.Quantity,
                }).ToList(),
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                ZipCode = model.ZipCode,
                Country = model.Country
            };

            await _orderRepo.AddOrderAsync(order);

            order.PaymentStatus = "Completed";
            await _orderRepo.UpdateOrderAsync(order);

            await _cartRepo.ClearCart(user.Id);

            return RedirectToAction("Confirmation", new { orderId = order.Id });
        }

        public async Task<IActionResult> Confirmation(int orderId)
        {
            var order = await _orderRepo.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return NotFound("Order not found!");
            }

            var confirmationVM = new CheckoutVM
            {
                OrderId = order.Id,
                BuyerId = order.UserId,
                TotalAmount = order.TotalAmount,
                CartItems = order.OrderDetails.Select(x => new CartItemVM
                {
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity,
                    ImageUrl = x.ImagePath
                }).ToList(),
                AddressLine1 = order.AddressLine1,
                AddressLine2 = order.AddressLine2,
                City = order.City,
                ZipCode = order.ZipCode,
                Country = order.Country
            };

            return View(confirmationVM);
        }

        private bool IsValidPayment(string cardNumber, string expirationDate, string cvv)
        {
            // Implement payment validation logic here
            return true;
        }
    }
}
