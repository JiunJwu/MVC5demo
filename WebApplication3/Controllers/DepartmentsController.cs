using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DepartmentsController : Controller
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Department);
        }
        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.FirstName), "ID", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                //db.Department.Add(department);
                var c = db.Department.Create();
                c.InjectFrom(department);
                db.Department.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p => p.FirstName), "ID", "FirstName");

            return View();
        }

        public ActionResult Edit(int? ID)
        {
            if (!ID.HasValue)
            {
                return HttpNotFound();
            }
            var dept = db.Department.Find(ID);
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName",dept.InstructorID);
            return View(db.Department.Find(ID.Value));
        }

        [HttpPost]
        public ActionResult Edit(int ID, DepartmentEdit department)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(ID);
                item.InjectFrom(department);
                //item.Name = department.Name;
                //item.Budget = department.Budget;
                //item.StartDate = department.StartDate;
                //item.InstructorID = department.InstructorID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var dept = db.Department.Find(ID);
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", dept.InstructorID);
            return View(dept);
        }
        public ActionResult Details(int? ID)
        {
            if (!ID.HasValue)
            {
                return HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            return View(db.Department.Find(ID));
        }
        public ActionResult Delete(int? ID)
        {
            if (!ID.HasValue)
            {
                return HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");
            return View(db.Department.Find(ID));
        }
        [HttpPost]
        public ActionResult Delete(int ID, Department department)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(ID);
                db.Department.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}