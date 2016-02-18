using DemoData.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models.Domain;

namespace Demo.Web.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            var empRepo = new EmployeeRepository();
            var employees = empRepo.GetEmployees();
            return View(employees);
        }

        public ActionResult Create()
        {
            var model = new Employee();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var empRepo = new EmployeeRepository();
                empRepo.SaveEmployee(model);

                return RedirectToAction("Index");
            }

            ViewBag.Message = "Error";
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var empRepo = new EmployeeRepository();
            var model = empRepo.GetEmployees().FirstOrDefault(x => x.Id == id);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var empRepo = new EmployeeRepository();
                empRepo.SaveEmployee(model);

                return RedirectToAction("Index");
            }

            ViewBag.Message = "Error";
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var empRepo = new EmployeeRepository();

            empRepo.DeleteEmployee(id);

            return RedirectToAction("Index");
        }

    }
}