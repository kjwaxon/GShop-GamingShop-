using ApplicationCore.DTO_s.CategoryDTO;
using ApplicationCore.DTO_s.SubcategoryDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using AutoMapper;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using WEB.Models.ViewModels;

namespace WEB.Controllers
{
    public class SubcategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly ISubcategoryRepository _subcategoryRepo;

        public SubcategoryController(ICategoryRepository categoryRepo,IProductRepository productRepo,IMapper mapper,ISubcategoryRepository subcategoryRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _mapper = mapper;
            _subcategoryRepo = subcategoryRepo;
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var subcategories = await _subcategoryRepo.GetFilteredListAsync
                 (
                     select: x => new GetSubcategoryVM
                     {
                         Id = x.Id,
                         SubcategoryName = x.SubcategoryName,
                         CategoryName = x.Category.CategoryName,
                         CreatedDate = x.CreatedDate,
                         UpdatedDate = x.UpdatedDate,
                         Status = x.Status
                     },
                     where: x => x.Status != Status.Passive,
                     orderBy: x => x.OrderByDescending(y => y.CreatedDate)
                 );
            return View(subcategories);
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateSubcategory()
        {
            var categories = await _categoryRepo.GetFilteredListAsync
                (
                    select:x=> new ShowCategoryDTO
                    {
                        Id=x.Id,
                        Name=x.CategoryName
                    },
                    where:x=>x.Status!=Status.Passive,
                    orderBy:x=>x.OrderByDescending(y=>y.CreatedDate)
                );
            var model =new CreateSubcategoryDTO { Categories = categories };
            return View(model);
        }
        //[Authorize(Roles = "admin")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubcategory(CreateSubcategoryDTO model)
        {
            var categories = await _categoryRepo.GetFilteredListAsync
               (
                   select: x => new ShowCategoryDTO
                   {
                       Id = x.Id,
                       Name = x.CategoryName
                   },
                   where: x => x.Status != Status.Passive,
                   orderBy: x => x.OrderByDescending(y => y.CreatedDate)
               );

            model.Categories = categories;

            if (ModelState.IsValid)
            {
                if (await _subcategoryRepo.AnyAsync(x => x.Status != Status.Passive && x.SubcategoryName == model.SubcategoryName))
                {
                    TempData["Error"] = "This subcategory name is used. Please select another name!";
                    return View(model);
                }
                var subcategory = _mapper.Map<Subcategory>(model);
                await _subcategoryRepo.AddAsync(subcategory);
                TempData["Success"] = $"{subcategory.SubcategoryName} subcategory added.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Please fill the blanks according to rules below!";
            return View(model);
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateSubcategory(int id)
        {
            if (id > 0)
            {
                var subcategory = await _subcategoryRepo.GetByIdAsync(id);
                if (subcategory is not null)
                {
                    var categories = await _categoryRepo.GetFilteredListAsync
                        (
                            select: x => new ShowCategoryDTO
                            {
                                Id = x.Id,
                                Name = x.CategoryName
                            },
                            where: x => x.Status != Status.Passive,
                            orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                        );

                    var model = _mapper.Map<UpdateSubcategoryDTO>(subcategory);
                    model.Categories = categories;
                    return View(model);
                }
            }
            TempData["Error"] = "Subcategory not found!";
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "admin")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSubcategory(UpdateSubcategoryDTO model)
        {
            var categories = await _categoryRepo.GetFilteredListAsync
                        (
                            select: x => new ShowCategoryDTO
                            {
                                Id = x.Id,
                                Name = x.CategoryName
                            },
                            where: x => x.Status != Status.Passive,
                            orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                        );
            model.Categories = categories;

            var subcategory = await _subcategoryRepo.GetByIdAsync(model.Id);

            if (subcategory != null)
            {
                if (ModelState.IsValid)
                {
                    if (await _subcategoryRepo.AnyAsync(x =>
                                                        x.Status != Status.Passive &&
                                                        x.Id != model.Id &&
                                                        x.SubcategoryName == model.SubcategoryName))
                    {
                        TempData["Error"] = "This subcategory name is been used.Please choose another name!";
                        return View(model);
                    }
                    var entity = _mapper.Map<Subcategory>(model);
                    await _subcategoryRepo.UpdateAsync(entity);
                    TempData["Success"] = $"{entity.SubcategoryName} subcategory is updated!";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Please fill the blanks according to rules below!";
                return View(model);
            }
            TempData["Error"] = "Subcategory not found!";
            return RedirectToAction("Index");

        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteSubcategory(int id)
        {
            if (id > 0)
            {
                var subcategory = await _subcategoryRepo.GetByIdAsync(id);

                if (subcategory is not null)
                {
                    if (await _subcategoryRepo.IsThereAnyProducts(id))
                    {
                        TempData["Error"] = "There are products saved in this. Can't delete!";
                        return RedirectToAction("Index");
                    }
                    await _subcategoryRepo.DeleteAsync(subcategory);
                    TempData["Success"] = $"{subcategory.SubcategoryName} is deleted!";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Subcategory not found!";
            return RedirectToAction("Index");
        }

    }
}
