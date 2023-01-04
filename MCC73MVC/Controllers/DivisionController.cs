using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class DivisionController : Controller
    {
        private DivisionRepositories _repo;

        public DivisionController(DivisionRepositories repo)
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
        public IActionResult Create(Division division)
        {
            var result = _repo.Insert(division);
            if (result > 0)
            {
                return RedirectToAction("Index", "Division"); // Method Index Controller Division
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
        public IActionResult Edit(Division division)
        {
            var result = _repo.Update(division);

            if (result > 0)
            {
                return RedirectToAction("Index", "Division"); // Method Index Controller Division
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
                return RedirectToAction("Index", "Division"); // Method Index Controller Division
            }
            return View();
        }
    }
}

