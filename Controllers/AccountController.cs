using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Models.ViewModels;
using MyApp.ModelServices;

namespace MyApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyAppDbContext _context;
        private readonly UserService _userService;

        public AccountController(MyAppDbContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            if (!ModelState.IsValid || _context.Users == null)
            {
                ViewData["ErrorMessage"] = "Registration not successful! Check your data!";
                return View(registerUserViewModel);
            }

            try
            {
                await _userService.CreateUserAsync(registerUserViewModel);
                ViewData["SuccessMessage"] = "Registration successful!";
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"Something went wrong! {ex}";
                return View(registerUserViewModel);
            }
        }
    }
}
