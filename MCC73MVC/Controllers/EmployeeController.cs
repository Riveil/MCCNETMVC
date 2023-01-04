using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepositories _repo;
        private DepartmentRepositories _repo2;

        public EmployeeController(EmployeeRepositories repo, DepartmentRepositories repo2)
        {
            _repo = repo;
            _repo2 = repo2;

        }
        public IActionResult Index()
        {

            var result = _repo.Get();
            var model = _repo2.Get();
            ViewBag.Model = model;
            return View(result);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            var model = _repo2.Get();
            ViewBag.Model = model;
            return View();
        }
        //POST - CREATE

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var result = _repo.Insert(employee);
            if (result > 0)
            {
                return RedirectToAction("Index", "Employee"); // Method Index Controller Division
            }
            return View();
        }

        //GET - By ID
        public IActionResult Details(string id)
        {
            var result = _repo.Get(id);
            var model = _repo2.Get();
            ViewBag.Model = model;
            return View(result);
        }


        // GET - Edit
        public IActionResult Edit(string id)
        {
            var result = _repo.Get(id);
            var model = _repo2.Get();
            ViewBag.Model = model;
            return View(result);
        }
        //POST - Edit
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var result = _repo.Update(employee);
            if (result > 0)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        //GET - DELETE
        public IActionResult Delete(string id)
        {
            var result = _repo.Get(id);
            var model = _repo2.Get();
            ViewBag.Model = model;
            return View(result);
        }
        //POST - DELETE
        [HttpPost]
        public IActionResult Deletes(string id)
        {
            var result = _repo.Delete(id);

            if (result > 0)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
    }
}
