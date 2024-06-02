using ApplicationCore.DTO_s.ProductDTO;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.ProductValidators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator()
        {
            var regex = new Regex("^[a-zA-Z-  |&.,’/ığüşöçİĞÜŞÖÇ0123456789]*$");
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Product name can't be empty!")
                .MinimumLength(2)
                .WithMessage("Product name can be minimum 2 characters!")
                .MaximumLength(100)
                .WithMessage("Product name can be maximum 100 characters!")
                .Matches(regex)
                .WithMessage("You can only enter letters,numbers and \"-\"!");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Product description can't be empty!")
                .MinimumLength(3)
                .WithMessage("Product description can be minimum 3 characters!")
                .MaximumLength(250)
                .WithMessage("Product description can be maximum 250 characters!")
                .Matches(regex)
                .WithMessage("You can only enter letters,numbers and \"-\"!");

            RuleFor(x => x.UnitPrice)
             .NotEmpty()
             .WithMessage("Price can't be empty!")
             .GreaterThan(0)
             .WithMessage("The price must be greater than zero.");

            RuleFor(x => x.Quantity)
             .NotEmpty()
             .WithMessage("Quantity can't be empty!")
             .GreaterThan(0)
             .WithMessage("The quantity must be greater than zero.");

            RuleFor(x=>x.UploadImage)
              .Must(BeAValidImage).WithMessage("Please upload a valid image")
              .Must(BeWithinAllowedFileSize).WithMessage("The image size must be less than 2MB.");

            RuleFor(x => x.SubcategoryId)
                .NotEmpty()
                .WithMessage("Subcategory can't be empty!");

        }

        private bool BeAValidImage(IFormFile? img)
        {
            if (img == null)
                return true;

            var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(img.FileName)?.ToLower();
            return validExtensions.Contains(extension);
        }

        private bool BeWithinAllowedFileSize(IFormFile? img)
        {
            if (img is null)
                return true;

            const long maxFileSizeInBytes = 2 * 1024 * 1024;
            return img==null || img.Length <= maxFileSizeInBytes;
        }
    }
}
