using MCC73MVC.Models;
using MCC73MVC.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Controllers
{
    public class AccountRoleController : Controller
    {
        private AccountRoleRepositories _repo;
        private EmployeeRepositories _emprepo;
        private RoleRepositories _rolerepo;


        public AccountRoleController(AccountRoleRepositories repo, EmployeeRepositories emprepo, RoleRepositories rolerepo )
        {
            _repo = repo;
            _emprepo = emprepo;
            _rolerepo = rolerepo;
        }
        public IActionResult Index()
        {

            var result = _repo.Get();
            //var accrepo_model = _accrepo.Get();
            //var rolerepo_model = _rolerepo.Get();
            //ViewBag.AccModel = accrepo_model;
            //ViewBag.RoleModel = rolerepo_model;
            return View(result);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            var emprepo_model = _emprepo.Get();
            var rolerepo_model = _rolerepo.Get();
            ViewBag.EmpModel = emprepo_model;
            ViewBag.RoleModel = rolerepo_model;
            return View();
        }
        //POST - CREATE

        [HttpPost]
        public IActionResult Create(AccountRole accountrole)
        {
            var result = _repo.Insert(accountrole);
            if (result > 0)
            {
                return RedirectToAction("Index", "AccountRole"); // Method Index Controller Division
            }
            return View();
        }

        //GET - By ID
        public IActionResult Details(int id)
        {
            var result = _repo.Get(id);
            var emprepo_model = _emprepo.Get();
            var rolerepo_model = _rolerepo.Get();
            ViewBag.EmpModel = emprepo_model;
            ViewBag.RoleModel = rolerepo_model;
            return View(result);
        }


        // GET - Edit
        public IActionResult Edit(int id)
        {
            var result = _repo.Get(id);
            var emprepo_model = _emprepo.Get();
            var rolerepo_model = _rolerepo.Get();
            ViewBag.EmpModel = emprepo_model;
            ViewBag.RoleModel = rolerepo_model;
            return View(result);
        }
        //POST - Edit
        [HttpPost]
        public IActionResult Edit(AccountRole accountrole)
        {
            var result = _repo.Update(accountrole);
            if (result > 0)
            {
                return RedirectToAction("Index", "AccountRole");
            }
            return View();
        }

        //GET - DELETE
        public IActionResult Delete(int id)
        {
            var result = _repo.Get(id);
            var emprepo_model = _emprepo.Get();
            var rolerepo_model = _rolerepo.Get();
            ViewBag.EmpModel = emprepo_model;
            ViewBag.RoleModel = rolerepo_model;
            return View(result);
        }
        //POST - DELETE
        [HttpPost]
        public IActionResult Deletes(int id)
        {
            var result = _repo.Delete(id);

            if (result > 0)
            {
                return RedirectToAction("Index", "AccountRole");
            }
            return View();
        }
    }
}
