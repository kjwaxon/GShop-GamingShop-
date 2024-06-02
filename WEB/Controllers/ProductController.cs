﻿using ApplicationCore.DTO_s.ProductDTO;
using ApplicationCore.DTO_s.SubcategoryDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using AutoMapper;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.Models.ViewModels;

namespace WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ISubcategoryRepository _subcategoryRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository productRepo,ISubcategoryRepository subcategoryRepo,IMapper mapper,IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = productRepo;
            _subcategoryRepo = subcategoryRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetFilteredListAsync
                (
                    select:x=> new GetProductVM
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,  
                        ProductDescription=x.Description,
                        UnitPrice= x.UnitPrice,
                        Quantity = x.Quantity,  
                        Image=x.ImagePath,
                        SubcategoryName=x.Subcategory.SubcategoryName,
                        CreatedDate=x.CreatedDate,
                        UpdatedDate=x.UpdatedDate,
                        Status = x.Status
                    },
                    where:x=>x.Status!=Status.Passive,
                    join:x=>x.Include(y=>y.Subcategory)
                );
            return View(products);
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateProduct()
        {
            var subcategories = await _subcategoryRepo.GetFilteredListAsync
                (
                    select:x=> new ShowSubcategoryDTO
                    {
                        Id=x.Id,
                        Name=x.SubcategoryName
                    },
                    where:x=>x.Status!=Status.Passive,
                    orderBy:x=>x.OrderByDescending(y=>y.CreatedDate)
                );
            var model = new CreateProductDTO { Subcategories = subcategories };
            return View(model); 
        }
        //[Authorize(Roles = "admin")]
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
                if (await _productRepo.AnyAsync(x=>x.Status!=Status.Passive && x.ProductName == model.ProductName))
                {
                    TempData["Error"] = "This product name is used. Please select another name!";
                    return View(model);
                }
                string imageName ="default.png";
                if (model.UploadImage!=null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/product");
                    imageName = $"{Guid.NewGuid()}_{model.UploadImage.FileName}";
                    string filePath=Path.Combine(uploadDir, imageName);
                    FileStream fileStream= new FileStream(filePath,FileMode.Create);
                    await model.UploadImage.CopyToAsync(fileStream);
                    fileStream.Close();
                }

                var product = _mapper.Map<Product>(model);
                product.ImagePath= imageName;
                await _productRepo.AddAsync(product);
                TempData["Success"] = $"{product.ProductName} product added!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Please fill the blanks according to rules below!";
            return View(model);
        }
        //[Authorize(Roles = "admin")]
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
                    model.Subcategories= subcategories;
                    return View(model);
                }
            }
            TempData["Error"] = "Product not found!";
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "admin")]
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
                    string imageName = model.Image;
                    if (model.UploadImage != null)
                    {
                        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/product");

                        if (!string.Equals(model.Image, "default.png"))
                        {
                            string oldPath = Path.Combine(uploadDir, model.Image);
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }

                        }
                        imageName = $"{Guid.NewGuid()}_{model.UploadImage.FileName}";
                        string filePath = Path.Combine(uploadDir, imageName);
                        FileStream fileStream = new FileStream(filePath, FileMode.Create);
                        await model.UploadImage.CopyToAsync(fileStream);
                        fileStream.Close();
                    }
                    var entity = _mapper.Map<Product>(model);
                    entity.ImagePath= imageName;
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
        //[Authorize(Roles = "admin")]
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