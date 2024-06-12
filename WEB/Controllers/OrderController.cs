using ApplicationCore.Entities.Concrete;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using WEB.Models.ViewModels;

namespace WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IUserRepository _userRepo;

        public OrderController(IOrderRepository orderRepo,IUserRepository userRepo)
        {
            _orderRepo = orderRepo;
            _userRepo = userRepo;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            var orders = await _orderRepo.GetOrdersByUserIdAsync(user.Id);
            var orderVMs = orders.Select(order => new GetOrderVM
            {
                Id = order.Id,
                TotalAmount = order.TotalAmount,
                PaymentStatus = order.PaymentStatus,
                AddressLine1 = order.AddressLine1,
                AddressLine2 = order.AddressLine2,
                City = order.City,
                ZipCode = order.ZipCode,
                Country = order.Country,
                OrderDetails = order.OrderDetails.Select(detail => new GetOrderDetailVM
                {
                    ProductName = detail.ProductName,
                    UnitPrice = detail.UnitPrice,
                    Quantity = detail.Quantity,
                    ImageUrl = detail.ImagePath
                }).ToList()
            }).ToList();
            return View(orderVMs);
        }
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound("Order not found!");
            }

            var orderVM = new GetOrderVM
            {
                Id = order.Id,
                TotalAmount = order.TotalAmount,
                PaymentStatus = order.PaymentStatus,
                AddressLine1 = order.AddressLine1,
                AddressLine2 = order.AddressLine2,
                City = order.City,
                ZipCode = order.ZipCode,
                Country = order.Country,
                OrderDetails = order.OrderDetails.Select(detail => new GetOrderDetailVM
                {
                    ProductName = detail.ProductName,
                    UnitPrice = detail.UnitPrice,
                    Quantity = detail.Quantity,
                    ImageUrl = detail.ImagePath
                }).ToList()
            };

            return View(orderVM);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrder(GetOrderVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var order = await _orderRepo.GetOrderByIdAsync(model.Id);
            if (order == null)
            {
                return NotFound("Order not found!");
            }

            order.PaymentStatus = model.PaymentStatus;
            order.TotalAmount = model.TotalAmount;
            order.AddressLine1 = model.AddressLine1;
            order.AddressLine2 = model.AddressLine2;
            order.City = model.City;
            order.ZipCode = model.ZipCode;
            order.Country = model.Country;
            order.OrderDetails = model.OrderDetails.Select(detail => new OrderDetail
            {
                ProductName = detail.ProductName,
                UnitPrice = detail.UnitPrice,
                Quantity = detail.Quantity,
                ImagePath = detail.ImageUrl
            }).ToList();

            await _orderRepo.UpdateOrderAsync(order);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound("Order not found!");
            }

            await _orderRepo.DeleteOrderAsync(order);
            return RedirectToAction("Index");
        }

    }
}
