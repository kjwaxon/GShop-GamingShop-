using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using DataAccess.Context;
using DataAccess.Services.Concrete;
using DataAccess.Services.Interface;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;
using WEB.Models;
using WEB.Models.ViewModels;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }
        public async Task<IActionResult> Index(string searchTerm = "", int subcategoryId = 0, int categoryId = 0)
        {
            IEnumerable<Product> products = await _homeRepository.GetProducts(searchTerm, subcategoryId, categoryId);
            IEnumerable<Subcategory> subcategories = await _homeRepository.GetSubcategories(categoryId);
            IEnumerable<Category> categories = await _homeRepository.GetCategories();
            var productModel = await _homeRepository.GetFilteredListAsync
                (
                    select:x=> new ProductViewModel
                    {
                        Products = products,
                        Subcategories = subcategories,
                        Categories = categories,
                        SearchTerm = searchTerm,
                        SubcategoryId = subcategoryId,
                        CategoryId = categoryId
                    },
                    where:x=>x.Status!=Status.Passive,
                    orderBy:x=>x.OrderByDescending(y=>y.CreatedDate)
                );
            var model = productModel.FirstOrDefault();
            return View(model);
        }


        [Authorize(Roles = "user")]
        public IActionResult ResetFilters()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
