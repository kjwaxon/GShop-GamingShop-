using ApplicationCore.DTO_s.OrderDTO;
using ApplicationCore.Entities.Concrete;
using DataAccess.Services.Concrete;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IOrderRepository _orderRepo;

        public DashboardController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<IActionResult> GetOrderById(int id)
        {
            var order  = await _orderRepo.GetOrderById(id);
            if (order==null)
            {
                TempData["Error"] = "Order not found";
                return RedirectToAction("Index", "Home");
            }
            return View(order);
        }
        
        public async Task<IActionResult> AllOrders()
        {
            var orders = await _orderRepo.GetOrders(true);
            return View(orders);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePaymentStatus(int id)
        {
            try
            {
                await _orderRepo.UpdatePaymentStatus(id);
                TempData["Success"] = "Payment status updated successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Failed to update payment status: {ex.Message}";
            }
            return RedirectToAction("GetOrderById", new { id });
        }

        public async Task<IActionResult> UpdateOrderStatus(int orderId)
        {
            var order = await _orderRepo.GetOrderById(orderId);
            if (order == null)
            {
                TempData["Error"] = "Order not found.";
                return RedirectToAction("Index", "Home");
            }

            var statuses = await _orderRepo.GetOrderStatuses();

            var model = new UpdateOrderDTO
            {
                OrderId = orderId,
                OrderStatusId = order.OrderStatusId,
                Statuses = statuses.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.StatusName
                })
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrderStatus(UpdateOrderDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _orderRepo.UpdateOrderStatus(model);
                    TempData["Success"] = "Order status updated successfully.";
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Failed to update order status: {ex.Message}";
                }
            }
            else
            {
                TempData["Error"] = "Invalid data.";
            }
            return RedirectToAction("GetOrderById", new { id = model.OrderId });
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
