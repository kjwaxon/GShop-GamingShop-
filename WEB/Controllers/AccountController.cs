using ApplicationCore.DTO_s.Abstract;
using ApplicationCore.DTO_s.AccountDTO;
using ApplicationCore.Entities.UserEntities.Concrete;
using AutoMapper;
using DataAccess.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IUserRepository userRepo, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userRepo = userRepo;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Login() => View();

        [AllowAnonymous,HttpPost,ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result= await _signInManager.PasswordSignInAsync(model.Username!,model.Password!,model.RememberMe,false);
                if (result.Succeeded)
                {
                    var appUser = await _userRepo.FindUser(HttpContext.User);
                    if (appUser is not null)
                    {
                        if (await _userRepo.IsUserInRole(appUser, "admin"))
                        {
                            TempData["Success"] = "Welcome Admin!";
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        }
                        else
                        {
                            TempData["Success"] = $"Welcome {appUser.UserName}!";
                            return RedirectToAction("Index","Home");
                        }
                    }
                    TempData["Error"] = "User not found!";
                    return View(model);
                }
                TempData["Error"] = "Username or password is false!";
                return View(model);
            }
            TempData["Error"] = "Please fill the blanks according to rules below!";
            return View(model);
        }

        [AllowAnonymous]

        public IActionResult Register() => View();

        [AllowAnonymous,HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                if (await _userRepo.IsEmailUsed(model.Email))
                {
                    TempData["Error"] = "This e-mail is already registered!";
                    return View(model);
                }
                AppUser appUser = new()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                    BirthDate=(DateTime)model.BirthDate,
                    Address = model.Address,

                };
                var result = await _userManager.CreateAsync(appUser,model.Password!);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, false);
                    TempData["Success"] = $"{appUser.UserName} you have been registered. Welcome {appUser.FirstName} {appUser.LastName}!";
                    return RedirectToAction("Index","Home");
                }
                TempData["Error"] = "User could`nt get registered!";
                return View(model);

            }
            TempData["Error"] = "Please fill the blanks according to rules below!";
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            if (user != null)
            {
                var model = new ChangePasswordDTO { Id = id };
                return View(model);
            }
            TempData["Error"] = "User not found!";
            return RedirectToAction("Login");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userRepo.FindUser(model.Id);
                var result = await _userRepo.ChangePassword(appUser, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _userRepo.Logout();
                    TempData["Success"] = "Password change successfull. Please login!";
                    return RedirectToAction("Login");
                }
                TempData["Error"] = "Password couldn't be changed!";
                return View(model);
            }
            TempData["Error"] = "Please fill the blanks according to rules below!";
            return View(model);
        }
        public async Task<IActionResult> EditUser()
        {
            var user = await _userRepo.FindUser(HttpContext.User);
            if (user != null)
            {
                var model = new EditUserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    BirthDate = user.BirthDate,
                    Password = user.PasswordHash,
                    Address= user.Address,  
                    CreatedDate = user.CreatedDate,
                    UpdatedDate = user.UpdatedDate
                };
                return View(model);
            }
            TempData["Error"] = "You have to login to view this page!";
            return RedirectToAction("Login");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserDTO model)
        {
            var user = await _userRepo.FindUser(HttpContext.User);

            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    var result = await _userRepo.UpdateAppUser(model);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Profile is updated!";
                    }
                    else
                    {
                        TempData["Error"] = "Profile couldn't get updated!";
                    }
                }
                else
                {
                    TempData["Error"] = "User not found!";
                }
            }
            else
            {
                TempData["Error"] = "Please fill the blanks according to rules below!";
            }
            return View(model);
        }
    }
}
