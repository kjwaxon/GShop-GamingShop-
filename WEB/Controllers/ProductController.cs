using ApplicationCore.DTO_s.ProductDTO;
using ApplicationCore.DTO_s.SubcategoryDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.Models.ViewModels;

namespace WEB.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepo;
        private readonly ISubcategoryRepository _subcategoryRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext context,IProductRepository productRepo, ISubcategoryRepository subcategoryRepo, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _productRepo = productRepo;
            _subcategoryRepo = subcategoryRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Where(x => x.Status != Status.Passive)
                .Include(x => x.Subcategory)
                .Include(x => x.Stock)
                .Select(x => new GetProductVM
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ProductDescription = x.Description,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Stock != null ? x.Stock.Quantity : 0,
                    Image = x.ImagePath,
                    SubcategoryName = x.Subcategory != null ? x.Subcategory.SubcategoryName : string.Empty,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Status = x.Status
                })
                .ToListAsync();

            return View(products);
        }


        public async Task<IActionResult> CreateProduct()
        {
            var subcategories = await _subcategoryRepo.GetFilteredListAsync
                (
                    select: x => new ShowSubcategoryDTO
                    {
                        Id = x.Id,
                        Name = x.SubcategoryName
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(y => y.CreatedDate)
                );
            var model = new CreateProductDTO { Subcategories = subcategories };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateProduct(CreateProductDTO model)
        {
            var subcategories = await _subcategoryRepo.GetFilteredListAsync
                (
                    select: x => new ShowSubcategoryDTO
                    {
                        Id = x.Id,
                        Name = x.SubcategoryName
                    },
                    where: x => x.Status != Status.Passive,
                    orderBy: x => x.OrderByDescending(y => y.CreatedDate)
                );
            model.Subcategories = subcategories;

            if (ModelState.IsValid)
            {
                if (await _productRepo.AnyAsync(x => x.Status != Status.Passive && x.ProductName == model.ProductName))
                {
                    TempData["Error"] = "This product name is used. Please select another name!";
                    return View(model);
                }
                string imageName = "default.png";
                if (model.UploadImage != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/product");
                    imageName = $"{Guid.NewGuid()}_{model.UploadImage.FileName}";
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await model.UploadImage.CopyToAsync(fileStream);
                    fileStream.Close();
                }

                var product = _mapper.Map<Product>(model);
                product.ImagePath = imageName;
                await _productRepo.AddAsync(product);
                TempData["Success"] = $"{product.ProductName} product added!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Please fill the blanks according to rules below!";
            return View(model);
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            if (id > 0)
            {
                var product = await _productRepo.GetByIdAsync(id);
                if (product is not null)
                {
                    var subcategories = await _subcategoryRepo.GetFilteredListAsync
                        (
                            select: x => new ShowSubcategoryDTO
                            {
                                Id = x.Id,
                                Name = x.SubcategoryName
                            },
                            where: x => x.Status != Status.Passive,
                            orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                        );

                    var model = _mapper.Map<UpdateProductDTO>(product);
                    model.Subcategories = subcategories;
                    return View(model);
                }
            }
            TempData["Error"] = "Product not found!";
            return RedirectToAction("Index");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO model)
        {
            var subcategories = await _subcategoryRepo.GetFilteredListAsync
                        (
                            select: x => new ShowSubcategoryDTO
                            {
                                Id = x.Id,
                                Name = x.SubcategoryName
                            },
                            where: x => x.Status != Status.Passive,
                            orderBy: x => x.OrderByDescending(z => z.CreatedDate)
                        );
            model.Subcategories = subcategories;

            var product = await _productRepo.GetByIdAsync(model.Id);

            if (product != null)
            {
                if (ModelState.IsValid)
                {
                    if (await _productRepo.AnyAsync(x =>
                                                        x.Status != Status.Passive &&
                                                        x.Id != model.Id &&
                                                        x.ProductName == model.ProductName))
                    {
                        TempData["Error"] = "This product name is been used.Please choose another name!";
                        return View(model);
                    }
                    string imageName = product.ImagePath;


                    if (model.UploadImage != null)
                    {
                        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/product");

                        if (!string.Equals(product.ImagePath, "default.png", StringComparison.OrdinalIgnoreCase))
                        {

                            string oldPath = Path.Combine(uploadDir, imageName);
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }

                        }

                        imageName = $"{Guid.NewGuid()}_{model.UploadImage.FileName}";
                        string filePath = Path.Combine(uploadDir, imageName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.UploadImage.CopyToAsync(fileStream);
                        }

                    }
                    var entity = _mapper.Map<Product>(model);
                    entity.ImagePath = imageName;
                    await _productRepo.UpdateAsync(entity);
                    TempData["Success"] = $"{entity.ProductName} product is updated!";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Please fill the blanks according to rules below!";
                return View(model);
            }
            TempData["Error"] = "Product not found!";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            if (product is not null)
            {
                await _productRepo.DeleteAsync(product);
                TempData["Success"] = $"{product.ProductName} is deleted!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Product not found!";
            return RedirectToAction("Index");
        }

    }
}
