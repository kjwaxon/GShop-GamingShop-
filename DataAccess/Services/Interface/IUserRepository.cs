using ApplicationCore.DTO_s.Abstract;
using ApplicationCore.DTO_s.AccountDTO;
using ApplicationCore.Entities.UserEntities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interface
{
    public interface IUserRepository
    {
        Task<bool> IsEmailUsed(string email);

        Task<AppUser> FindUser(string id);

        Task<AppUser> FindUser(ClaimsPrincipal claimsPrincipal);

        Task<bool> IsUserInRole(AppUser appUser, string roleName);

        Task<IdentityResult> UpdateAppUser(AppUser appUser);

        Task<IdentityResult> UpdateAppUser(EditUserDTO model);

        Task<IdentityResult> DeleteAppUser(AppUser appUser);
        Task<bool> Login(string userName, string password);

        Task Logout();

        Task<IdentityResult> ChangePassword(AppUser appUser, string oldPassword, string newPassword);
    }
}
