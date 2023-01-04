using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class RoleController : Controller
    {
        private RoleRepositories _repo;

        public RoleController(RoleRepositories repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var result = _repo.Get();
            return View(result);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }
        //POST - CREATE

        [HttpPost]
        public IActionResult Create(Role role)
        {
            var result = _repo.Insert(role);
            if (result > 0)
            {
                return RedirectToAction("Index", "Role"); // Method Index Controller Division
            }
            return View();
        }

        //GET - By ID
        public IActionResult Details(int id)
        {
            var result = _repo.Get(id);
            return View(result);
        }


        // GET - Edit
        public IActionResult Edit(int id)
        {
            var result = _repo.Get(id);
            return View(result);
        }
        //POST - Edit
        [HttpPost]
        public IActionResult Edit(Role role)
        {
            var result = _repo.Update(role);

            if (result > 0)
            {
                return RedirectToAction("Index", "Role"); // Method Index Controller Division
            }
            return View();
        }

        //GET - DELETE
        public IActionResult Delete(int id)
        {
            var result = _repo.Get(id);
            return View(result);
        }
        //POST - DELETE
        [HttpPost]
        public IActionResult Deletes(int id)
        {
            var result = _repo.Delete(id);

            if (result > 0)
            {
                return RedirectToAction("Index", "Role"); // Method Index Controller Division
            }
            return View();
        }
    }
}
