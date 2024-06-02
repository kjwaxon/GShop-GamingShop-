using ApplicationCore.DTO_s.SubcategoryDTO;
using ApplicationCore.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.SubcategoryValidators
{
    public class UpdateSubcategoryValidator:AbstractValidator<UpdateSubcategoryDTO>
    {
        public UpdateSubcategoryValidator()
        {
            var regex = new Regex("^[a-zA-Z-  |&.,’ığüşöçİĞÜŞÖÇ0123456789]*$");

            RuleFor(x => x.SubcategoryName)
                .NotEmpty()
                .WithMessage("Subcategory name can't be empty!")
                .MinimumLength(2)
                .WithMessage("Subcategory name can be minimum 2 characters!")
                .MaximumLength(100)
                .WithMessage("Subcategory name can be maximum 100 characters!")
                .Matches(regex)
                .WithMessage("You can only enter letters,numbers and \"-\"!");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Category can't be empty!");
        }
    }
}
