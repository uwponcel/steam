using steam.Data;
using steam.Data.Static;
using steam.Data.ViewModels;
using steam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }


        public IActionResult Login() => View(new LoginVm());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid) return View(loginVm);

            var user = await _userManager.FindByEmailAsync(loginVm.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVm.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Games");
                    }
                }
                TempData["Error"] = "Mauvais identifiants. Veuillez réessayer!";
                return View(loginVm);
            }

            TempData["Error"] = "Mauvais identifiants. Veuillez réessayer!";
            return View(loginVm);
        }


        public IActionResult Register() => View(new RegisterVm());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Cet email existe déjà";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Games");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

    }
}