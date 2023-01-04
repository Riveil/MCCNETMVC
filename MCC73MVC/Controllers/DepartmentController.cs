using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentRepositories _repo;
        private DivisionRepositories _repo2;

        public DepartmentController(DepartmentRepositories repo, DivisionRepositories repo2)
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
        public IActionResult Create(Department department)
        {
            var result = _repo.Insert(department);
            if (result > 0)
            {
                return RedirectToAction("Index", "Department"); // Method Index Controller Division
            }
            return View();
        }

        //GET - By ID
        public IActionResult Details(int id)
        {
            var result = _repo.Get(id);
            var model = _repo2.Get();
            ViewBag.Model = model;
            return View(result);
        }


        // GET - Edit
        public IActionResult Edit(int id)
        {
            var result = _repo.Get(id);
            var model = _repo2.Get();
            ViewBag.Model = model;
            return View(result);
        }
        //POST - Edit
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            var result = _repo.Update(department);
            if (result > 0)
            {
                return RedirectToAction("Index", "Department");
            }
            return View();
        }

        //GET - DELETE
        public IActionResult Delete(int id)
        {
            var result = _repo.Get(id);
            var model = _repo2.Get();
            ViewBag.Model = model;
            return View(result);
        }
        //POST - DELETE
        [HttpPost]
        public IActionResult Deletes(int id)
        {
            var result = _repo.Delete(id);

            if (result > 0)
            {
                return RedirectToAction("Index", "Department");
            }
            return View();
        }
    }
}
