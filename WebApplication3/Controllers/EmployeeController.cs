using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees;

        static EmployeeController()
        {
            employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, FirstName = "Alexander", LastName = "Protskevich", Age = 27, CompanyId = 1 });
        }

        public ActionResult Index(int companyId)
        {
            List<Employee> filteredEmployees = employees.Where(p => p.CompanyId == companyId).ToList();
            ViewBag.CompanyId = companyId;
            return View(filteredEmployees);
        }

        [HttpGet]
        public ActionResult Add(int companyId)
        {
            Employee employee = new Employee { CompanyId = companyId };
            ViewBag.Action = "Add";
            return View("Edit", employee);
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            employee.Id = employees.Count + 1;
            employees.Add(employee);
            return RedirectToAction("Index", new { companyId=employee.CompanyId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(p => p.Id == id);
            if (employee != null)
            {
                ViewBag.Action = "Edit";
                return View(employee);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var oldEmployee = employees.FirstOrDefault(p => p.Id == employee.Id);
            if (oldEmployee != null)
            {
                oldEmployee.FirstName = employee.FirstName;
                oldEmployee.LastName = employee.LastName;
                oldEmployee.Age = employee.Age;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(p => p.Id == id);
            employees.Remove(employee);
            return RedirectToAction("Index");
        }

    }
}