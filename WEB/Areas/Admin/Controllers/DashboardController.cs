using ApplicationCore.DTO_s.OrderDTO;
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

        
        public async Task<IActionResult> AllOrders()
        {
            var orders = await _orderRepo.GetOrders(true);
            return View(orders);
        }

        public async Task<IActionResult> TogglePaymentStatus(int orderId)
        {
            try
            {
                await _orderRepo.PaymentStatus(orderId);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction(nameof(AllOrders));
        }

        public async Task<IActionResult> UpdateOrderStatus(int orderId)
        {
            var order = await _orderRepo.GetOrderById(orderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order with id: {orderId} not found.");
            }

            var model = new UpdateOrderDTO
            {
                OrderId = orderId,
                OrderStatusId = order.OrderStatusId,
                OrderStatusList = await GetOrderStatusList(order.OrderStatusId)
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrderStatus(UpdateOrderDTO model)
        {
            if (!ModelState.IsValid)
            {
                model.OrderStatusList = await GetOrderStatusList(model.OrderStatusId);
                return View(model);
            }

            try
            {
                await _orderRepo.UpdateOrderStatus(model);
                TempData["Success"] = "Order updated successfully";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Something went wrong: " + ex.Message;
            }

            return RedirectToAction(nameof(UpdateOrderStatus), new { orderId = model.OrderId });
        }
        [Authorize(Roles ="admin")]
        public IActionResult Index()
        {
            return View();
        }

        private async Task<IEnumerable<SelectListItem>> GetOrderStatusList(int selectedStatusId)
        {
            var orderStatuses = await _orderRepo.GetOrderStatuses();
            return orderStatuses.Select(orderStatus => new SelectListItem
            {
                Value = orderStatus.Id.ToString(),
                Text = orderStatus.StatusName,
                Selected = orderStatus.Id == selectedStatusId
            }).ToList();
        }

    }
}
