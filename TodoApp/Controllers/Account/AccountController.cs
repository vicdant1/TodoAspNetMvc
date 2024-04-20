using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.ViewModels;
using TodoApp.Domain.Identity;
using TodoApp.Extensions;

namespace TodoApp.Controllers.Account
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerInput)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.GetNormalizedStringErrorMessages();
                return BadRequest(validationErrors);
            }

            var user = new AppUser
            {
                Email = registerInput.Email,
                UserName = registerInput.Email,
            };

            var result = await _userManager.CreateAsync(user, registerInput.Password!);
            if (result.Succeeded)
                return Ok();
            else
            {
                var registerErrors = String.Join("\n", result.Errors.Select(error => error.Description));
                return BadRequest($"It wasn't possible to create your user: {registerErrors}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginInput)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.GetNormalizedStringErrorMessages();
                return BadRequest(validationErrors);
            }

            var user = await _userManager.FindByEmailAsync(loginInput.Username!);
            if (user != null)
            {
                var login = await _signInManager.PasswordSignInAsync(user, loginInput.Password!, loginInput.RememberMe, lockoutOnFailure: false);
                if (login.Succeeded)
                    return Ok();
                else
                    return BadRequest("Failed login attempt");
            }
            else
            {
                return BadRequest("User not found!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
