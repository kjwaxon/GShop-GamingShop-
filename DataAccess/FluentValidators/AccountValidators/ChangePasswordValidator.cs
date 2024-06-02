using ApplicationCore.DTO_s.AccountDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentValidators.AccountValidators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .WithMessage("Old password must be filled!");

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage("New password must be filled!")
                .NotEqual(x => x.OldPassword)
                .WithMessage("New password can`t be same with old password!");

            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty()
                .WithMessage("New password must be filled!")
                .Equal(x => x.NewPassword)
                .WithMessage("Passwords doesn`t match!");
        }
    }
}
