using DreamsBytes.Core.Entites;
using DreamsBytes.Services;
using DreamsBytes.Services.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;

namespace DreamsBytes.Web.Controllers
{

    public class LoginController : Controller

    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        public LoginController(IUserService userService,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin([Bind] LoginViewModel user, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

               var verifiedUser = _userService.Login(user.Email, user.Password);
                if (verifiedUser.verified == false)
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı ya da şifre hatalı!");
                    return View(new LoginViewModel());
                }
                string userRole = nameof(UserRole.User);
                if (verifiedUser.user.UserRoleId == UserRole.Admin)
                {
                    userRole = nameof(UserRole.Admin);

                }
                ClaimsIdentity identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, verifiedUser.user.FirstName +" "+ verifiedUser.user.LastName),
                    new Claim(ClaimTypes.Email, verifiedUser.user.Email),
                    new Claim(ClaimTypes.Role, userRole),
                     new Claim(ClaimTypes.NameIdentifier, verifiedUser.user.Id.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                System.Threading.Tasks.Task login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties
                {
                    IsPersistent = user.RememberMe,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(600)
                });


                return RedirectToAction("Index", "Product");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("UserLogin", "Login");
        }
    }
}