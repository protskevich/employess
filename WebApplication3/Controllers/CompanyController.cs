using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CompanyController : Controller
    {
        static List<Company> companies;

        static CompanyController()
        {
            companies = new List<Company>();
            companies.Add(new Company { Id = 1, Name = "Belitsoft", Users = new List<Employee>() });
        }

        public ActionResult Index()
        {
            return View(companies);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Add(Company company)
        {
            company.Id = companies.Count + 1;
            companies.Add(company);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var company = companies.FirstOrDefault(p => p.Id == id);
            if (company != null)
            {
                ViewBag.Action = "Edit";
                return View(company);
            }

            return HttpNotFound();
        }
    }
}