using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppViewBagViewDataTempData.Models;

namespace WebAppViewBagViewDataTempData.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        static List<Emp> Listemp = new List<Emp>
        {
            new Emp{Id=1,Name="sandy",Designation="Developer",Salary=23000},
            new Emp{Id=2,Name="kiru",Designation="HR",Salary=24000},
            new Emp{Id=3,Name="Malu",Designation="Tester",Salary=25000},
            new Emp{Id=4,Name="Manju",Designation="Manager",Salary=26000},
            new Emp{Id=5,Name="Divya",Designation="Dotnet",Salary=27000},
            new Emp{Id=6,Name="Ila",Designation="Java developer",Salary=28000},


        };
        public ActionResult Index()
        {
            ViewBag.msg = "Welcome to Employee Management";
            ViewBag.noEmp = Listemp.Count;
            return View(Listemp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["msg"] = "Employee Registeration";
            return View(new Emp());
        }
        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                Listemp.Add(emp);
                TempData["tempmsg"] = "New Employee Registeration Success ";
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Emp emp = Listemp.SingleOrDefault(e => e.Id == id);

            return View(emp);
        }
               
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Emp emp=Listemp.SingleOrDefault( e => e.Id == id);   
            if (emp != null)
            {
              Listemp.Remove(emp);
            }
            return RedirectToAction("Index");


        }

    }
}