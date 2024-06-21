using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepo;

        public OrderController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderRepo.GetOrders();
            return View(orders);
        }
    }
}
