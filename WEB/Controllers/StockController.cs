using ApplicationCore.DTO_s.StockDTO;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepo;

        
        public StockController(IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(string searchTerm = "")
        {
            var stocks = await _stockRepo.GetStocks(searchTerm);
            return View(stocks);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateStock(int productId)
        {
            var existingStock = await _stockRepo.GetStockByProductId(productId);
            var stock = new UpdateStockDTO
            {
                ProductId = productId,
                Quantity = existingStock != null
            ? existingStock.Quantity : 0
            };
            return View(stock);
        }
        [Authorize(Roles = "admin")]
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStock(UpdateStockDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                await _stockRepo.UpdateStock(model);
                TempData["Success"] = "Stock is updated successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Something went wrong!!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
