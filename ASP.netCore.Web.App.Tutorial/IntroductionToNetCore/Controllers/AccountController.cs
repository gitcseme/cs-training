using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IntroductionToNetCore.Models;
using IntroductionToNetCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IntroductionToNetCore.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _logger = logger;
        }

        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public ILogger<AccountController> _logger { get; }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.City
                };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                    Log.Information(confirmationLink); // Useing log file instead of Email now.

                    if (SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }

                    ViewBag.ErrorTitle = "Registration is successfull";
                    ViewBag.ErrorMessage = "Click the confirmation link to confirm email for login in system";
                    return View("Error");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null && token == null)
                return RedirectToAction("Index", "Home");

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The user ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await UserManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return View();

            ViewBag.ErrorTitle = "Email can not confirmed";
            return View("Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            model.ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed && (await UserManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View(model);
                }

                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                        return RedirectToAction("index", "home");
                }

                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
                return Json($"Email {email} is already in use");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // External login
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl) // value is maped to provider here as name = "provider"
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });

            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties); // take us to google signin page.
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null) // Google call this method.
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error from external provider: {remoteError}");
                return View("Login", loginViewModel);
            }

            var userInfo = await SignInManager.GetExternalLoginInfoAsync(); // Google gives userInfo
            if (userInfo == null)
            {
                ModelState.AddModelError("", "Error loading external login information");
                return View("Login", loginViewModel);
            }

            var email = userInfo.Principal.FindFirstValue(ClaimTypes.Email);
            ApplicationUser user = null;
            
            if (email != null)
            {
                user = await UserManager.FindByEmailAsync(email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View("Login", loginViewModel);
                }
            }


            var signinResult = await SignInManager.ExternalLoginSignInAsync(userInfo.LoginProvider, userInfo.ProviderKey, 
                isPersistent: false, bypassTwoFactor: true); // Check AspNetUserLogin table to find corresponding entry to sign the user in.

            if (signinResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                if (email != null) // user has local account?
                {
                    if (user == null) // no local user account found
                    {
                        user = new ApplicationUser { UserName = email, Email = email };
                        await UserManager.CreateAsync(user); // Create new user to AspNetUsers table
                    }

                    await UserManager.AddLoginAsync(user, userInfo); // Add user entry to AspNetUserLogin table.
                    await SignInManager.SignInAsync(user, isPersistent: false); // sign the user in.

                    return LocalRedirect(returnUrl);
                }

                // If we do not receive email from [External Login Provider]
                ViewBag.ErrorTitle = $"Email claim not received from {userInfo.LoginProvider}";
                return View("Error");
            }
        }
    }
}
