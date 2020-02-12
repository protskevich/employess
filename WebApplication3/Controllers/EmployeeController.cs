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
            employees.Add(new Employee { Id = 1, FirstName = "Alexander", LastName = "Protskevich", Age = 27 });
        }
        public ActionResult Index()
        {
            return View(employees);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(p => p.Id == id);
            if (employee != null)
            {
                return View(employee);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var oldEmployee = employees.FirstOrDefault(p => p.Id == employee.Id);
            if (oldEmployee != null)
            {
                oldEmployee.FirstName = employee.FirstName;
                oldEmployee.LastName = employee.FirstName;
                oldEmployee.Age = employee.Age;
            }
            return RedirectToAction("Index");
        }
    }
}