using AlphaLife.WebApplication.Data;
using AlphaLife.WebApplication.Data.Static;
using AlphaLife.WebApplication.Data.ViewModels;
using AlphaLife.WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Users() => View(await _context.Users.ToListAsync());


        public IActionResult Login() => View(new LoginVM());

        //POST: Acount/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View(login);
            var user = await _userManager.FindByEmailAsync(login.EmailAddress);
            if (user == null) { TempData["Error"] = "Wrong credentials. please try again!"; return View(login); }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, login.Password);
            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Wrong credentials. please try again!";
            return View(login);

        }

        public IActionResult Register() => View(new RegisterVM());

        //POST: Acount/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null) { TempData["Error"] = "The Email Address Already Exist"; return View(registerVM); }
            var newuser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,
            };
            var result = await _userManager.CreateAsync(newuser, registerVM.Password);
            if (result.Succeeded)
                return View("RegisterCompleted");
            
            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

