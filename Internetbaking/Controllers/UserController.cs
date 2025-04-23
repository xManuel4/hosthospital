using Internetbaking.Core.Application.Dtos.Account;
using Internetbanking.Core.Application.Interfaces.Services;
using Internetbanking.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Internetbanking.Core.Application.Helpers;
using AutoMapper.Features;
using Internetbanking.Core.Application.Dtos.Account;


namespace Internetbanking.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            AuthenticationResponse userVm = await _userService.LoginAsync(vm);

            if (userVm != null && userVm.HasError != true) 
            {
                HttpContext.Session.Set<AuthenticationResponse>("user", userVm);
                return RedirectToRoute(new { controller =  "Home", action = "Index"});

            }
            else
            {
                vm.HasError = userVm.HasError;
                vm.Error = userVm.Error;
                return View(vm);

            }
            
        }
        public async Task<IActionResult> LogOut() 
        {
        
           await _userService.SignOutAsync();
           HttpContext.Session.Remove("user");
           return RedirectToRoute(new {controller = "user", action = "Index" });
        }

        public IActionResult Register() 
        {
            var user = HttpContext.Session.Get<AuthenticationResponse>("user");

            if (user != null)
            {

                return RedirectToAction("Index", "Home");
            }
            return View(new SaveUserViewnModel());
        }

        [HttpPost] 
        public async Task<IActionResult> Register(SaveUserViewnModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var origin = Request.Headers["origin"];
            RegisterResponse response = await _userService.RegisterAsync(vm, origin);
            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }

            return RedirectToRoute(new { controller = "User", action = "Index"});
        }
        
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            string response = await _userService.ConfirmEmailAsync(userId, token);
            return View(response);
        }

        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel vm)
        {
            if (!ModelState.IsValid) 
            {
                return View(vm);
            }

            var origin = Request.Headers["origin"];

            ForgotPasswordResponse response = await _userService.ForgotPasswordAsync(vm, origin);

            if(response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public IActionResult ResetPassword(string token) 
        { 
         return View(new ResetPasswordViewModel{
                Token = token
            });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            

            ResetPasswordResponse response = await _userService.ResetPasswordAsync(vm);

            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

    }
}
