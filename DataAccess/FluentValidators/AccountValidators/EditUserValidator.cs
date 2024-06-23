using ApplicationCore.DTO_s.AccountDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.AccountValidators
{
    public class EditUserValidator : AbstractValidator<EditUserDTO>
    {
        public EditUserValidator()
        {
            
            
            RuleFor(x => x.Address)
              .MaximumLength(250)
              .WithMessage("Adress can be maximum 250 characters!")
              .MinimumLength(10)
              .WithMessage("Adress can be minimum 10 characters!");
        }
    }
}
