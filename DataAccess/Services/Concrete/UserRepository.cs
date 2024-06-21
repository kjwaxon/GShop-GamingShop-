using ApplicationCore.DTO_s.Abstract;
using ApplicationCore.DTO_s.AccountDTO;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.UserEntities.Concrete;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }
        public async Task<IdentityResult> ChangePassword(AppUser appUser, string oldPassword, string newPassword)
            => await _userManager.ChangePasswordAsync(appUser, oldPassword, newPassword);
        public async Task<IdentityResult> DeleteAppUser(AppUser appUser)
            => await _userManager.DeleteAsync(appUser);

        public async Task<AppUser> FindUser(string id)
            => await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<AppUser> FindUser(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            return await FindUser(userId);
        }

        public async Task<bool> IsEmailUsed(string email)
            => await _userManager.Users.AnyAsync(x => x.Email == email);

        public async Task<bool> Login(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task Logout()
            => await _signInManager.SignOutAsync();
        public async Task<bool> IsUserInRole(AppUser appUser, string roleName)
            => await _userManager.IsInRoleAsync(appUser, roleName);

        public async Task<IdentityResult> UpdateAppUser(AppUser appUser)
        {
            if (!await _userManager.IsInRoleAsync(appUser,"admin"))
            {
                appUser.Status = Status.Modified;
                appUser.UpdatedDate = DateTime.Now;
            }
            var result = await _userManager.UpdateAsync(appUser);
            return result;
        }

        public async Task<IdentityResult> UpdateAppUser(EditUserDTO model)
        {
            var appUser = await FindUser(model.Id);
            if (appUser != null)
            {
                appUser.Email = model.Email;
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                appUser.BirthDate = (DateTime)model.BirthDate;
                appUser.Address=model.Address;
                if (model.Password != null)
                {
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, model.Password);
                }
                return await UpdateAppUser(appUser);
            }
            return null;
        }
    }
}
