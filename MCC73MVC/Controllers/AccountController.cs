using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using MCC73MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepositories _repo;
        public AccountController(AccountRepositories repo)
        {
            _repo = repo;
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Login")]
        public IActionResult Login(LoginVM login)
        {
            var result = _repo.Login(login);
            if (result == 2)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.error = "Login Failed";
            return View();
        }

        [HttpGet("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/Register")]
        public IActionResult Register(RegisterVM register)
        {
            var result = _repo.Register(register);
            if (result > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
