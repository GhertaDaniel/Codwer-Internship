using _5._BlogApp.DTO;
using _5._BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using _5._BlogApp.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _5._BlogApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AccountService _accountService;
        private readonly ApplicationDbContext _db;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AccountService accountService, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
            _db = db;
        }


        // GET: /<controller>/
        [HttpGet]
        [Authorize("NotAuthorized")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize("NotAuthorized")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values
                    .SelectMany(temp => temp.Errors)
                    .Select(temp => temp.ErrorMessage);
                return View(registerDTO);
            }

            ApplicationUser user = new()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
                PersonName = registerDTO.PersonName
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                //await _db.Users.Add();
                return RedirectToAction(nameof(BlogsController.Index), "Blogs");
            } else
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }

                return View(registerDTO);
            }
        }

        [HttpGet]
        [Authorize("NotAuthorized")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Authorize("NotAuthorized")]
        public async Task<IActionResult> Login(LoginDTO loginDTO, string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values
                    .SelectMany(temp => temp.Errors)
                    .Select(temp => temp.ErrorMessage);
                return View(loginDTO);
            }

            var result = await _signInManager.PasswordSignInAsync(
                loginDTO.Email,
                loginDTO.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if(result.Succeeded)
            {
                if(!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                {
                    return LocalRedirect(ReturnUrl);
                }
            }
            return RedirectToAction(nameof(BlogsController.Index), "Blogs");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(BlogsController.Index), "Blogs");
        }

        public async Task<IActionResult> IsEmailAlreadyRegistered(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else return Json(false);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = await _accountService.GetProfile(userId);
            return View(user);
        }
    }
}

