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
                TempData["Error"] = "This product name has been used. Please choose another name!";
                return View(model);
            }
            string imageName = product.ImagePath;
            if (model.UploadImage != null)
            {
                string uploadDir = _webHostEnvironment.WebRootPath;
                if (uploadDir == null)
                {
                    TempData["Error"] = "Invalid web root path.";
                    return View(model);
                }

                uploadDir = Path.Combine(uploadDir, "img", "product");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                if (!string.Equals(product.ImagePath, "default.png"))
                {
                    if (product.ImagePath == null)
                    {
                        TempData["Error"] = "Invalid image path.";
                        return View(model);
                    }

                    string oldPath = Path.Combine(uploadDir, product.ImagePath);
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
