using ApplicationCore.DTO_s.CategoryDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.CategoryValidators
{
    public class UpdateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        public UpdateCategoryValidator()
        {

            var regex = new Regex("^[a-zA-Z-  |&.,’ığüşöçİĞÜŞÖÇ0123456789]*$");

            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .WithMessage("Category name can't be empty!")
                .MinimumLength(2)
                .WithMessage("Category name can be minimum 2 characters!")
                .MaximumLength(100)
                .WithMessage("Category name can be maximum 100 characters!")
                .Matches(regex)
                .WithMessage("You can only enter letters,numbers and \"-\"!");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Category description can't be empty!")
                .MinimumLength(3)
                .WithMessage("Category description can be minimum 3 characters!")
                .MaximumLength(100)
                .WithMessage("Category description can be maximum 100 characters!")
                .Matches(regex)
                .WithMessage("You can only enter letters,numbers and \"-\"!");
        }
    }
}
