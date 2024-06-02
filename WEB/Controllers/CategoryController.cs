using ApplicationCore.DTO_s.CategoryDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using AutoMapper;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using WEB.Models.ViewModels;

namespace WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly ISubcategoryRepository _subcategoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepo,ISubcategoryRepository subcategoryRepo,IProductRepository productRepo,IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _subcategoryRepo = subcategoryRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepo.GetFilteredListAsync
                (
                    select:x => new GetCategoryVM
                    {
                        Id=x.Id,
                        CategoryName=x.CategoryName,
                        CategoryDescription=x.Description,
                        CreatedDate=x.CreatedDate,
                        UpdatedDate=x.UpdatedDate,
                        Status=x.Status
                    },
                    where:x=>x.Status!=Status.Passive,
                    orderBy:x=>x.OrderByDescending(y=>y.CreatedDate)
                );
            return View(categories);
        }

        public IActionResult CreateCategory() => View();

        //[Authorize(Roles = "admin")]
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryRepo.AnyAsync(x=>x.Status!=Status.Passive && x.CategoryName==model.CategoryName))
                {
                    TempData["Error"] = "This category name is used. Please select another name!";
                    return View(model);
                }
                var category = _mapper.Map<Category>(model);
                await _categoryRepo.AddAsync(category);
                TempData["Success"] = $"{category.CategoryName} category added.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Please fill the blanks according to rules below!";
            return View(model); 
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            if (id > 0)
            {
                var category = await _categoryRepo.GetByIdAsync(id);
                if (category is not null)
                {
                    var model = _mapper.Map<UpdateCategoryDTO>(category);
                    return View(model);
                }
            }
            TempData["Error"] = "Category not found!";
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "admin")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO model)
        {
            var category = await _categoryRepo.GetByIdAsync(model.Id);

            if (category != null)
            {
                if (ModelState.IsValid)
                {
                    if (await _categoryRepo.AnyAsync(x =>
                                                        x.Status != Status.Passive &&
                                                        x.Id != model.Id &&
                                                        x.CategoryName == model.CategoryName))
                    {
                        TempData["Error"] = "This category name is been used.Please choose another name!";
                        return View(model);
                    }
                    var entity = _mapper.Map<Category>(model);
                    await _categoryRepo.UpdateAsync(entity);
                    TempData["Success"] = $"{entity.CategoryName} category is updated!";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Please fill the blanks according to rules below!";
                return View(model);
            }
            TempData["Error"] = "Category not found!";
            return RedirectToAction("Index");

        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id > 0)
            {
                var category = await _categoryRepo.GetByIdAsync(id);

                if (category is not null)
                {
                    if (await _categoryRepo.IsThereAnySubcategories(id))
                    {
                        TempData["Error"] = "There are subcategories saved in this. Can't delete!";
                        return RedirectToAction("Index");
                    }
                    await _categoryRepo.DeleteAsync(category);
                    TempData["Success"] = $"{category.CategoryName} is deleted!";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Category not found!";
            return RedirectToAction("Index");
        }
    }
}
