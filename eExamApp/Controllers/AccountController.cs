using eExam.Core.Interfaces;
using eExam.Core.Services;
using eExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eExamApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            var dllUserType = new List<SelectListItem>();
            var option1 = new SelectListItem()
            {
                Text = "Admin",
                Value = "1"
            };
            var option2 = new SelectListItem()
            {
                Text = "Student",
                Value = "2"
            };

            dllUserType.Add(option1); dllUserType.Add(option2);
            var userVM = new UserVM();
            userVM.UserTypes = dllUserType;
            return View(userVM);
        }
        [HttpPost]
        public IActionResult Register(UserVM user)
        {
            string message=_accountService.UserRegistration(user.Name, user.Password, user.UserType);
            ViewBag.Message = message;
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult LogIn(UserVM user)
        {
            string message = _accountService.UserLogin(user.Name, user.Password);
            ViewBag.Message = message;
            if(message == "Login Success")
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
    }
}
