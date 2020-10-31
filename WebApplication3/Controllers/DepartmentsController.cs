using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DepartmentsController : BaseController
    {
        //ContosoUniversityEntities db = new ContosoUniversityEntities();
        DepartmentRepository repo;
        PersonRepository repoPerson;

        public DepartmentsController()
        {
            repo = RepositoryHelper.GetDepartmentRepository();
            repoPerson = RepositoryHelper.GetPersonRepository(repo.UnitOfWork);
        }

        // GET: Department
        public ActionResult Index()
        {
            return View(repo.All());
        }
        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                //db.Department.Add(department);
                repo.Add(department);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p => p.FirstName), "ID", "FirstName");

            return View();
        }

        public ActionResult Edit(int? ID)
        {
            if (!ID.HasValue)
            {
                return HttpNotFound();
            }
            var dept = repo.Get單一筆部門資料(ID.Value);
            ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName",dept.InstructorID);
            return View(repo.Get單一筆部門資料(ID.Value));
        }

        [HttpPost]
        public ActionResult Edit(int ID, DepartmentEdit department)
        {
            if (ModelState.IsValid)
            {
                var item = repo.Get單一筆部門資料(ID);
                item.InjectFrom(department);
                //item.Name = department.Name;
                //item.Budget = department.Budget;
                //item.StartDate = department.StartDate;
                //item.InstructorID = department.InstructorID;
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            var dept = repo.Get單一筆部門資料(ID);
            ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName", dept.InstructorID);
            return View(dept);
        }
        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dept = repo.Get單一筆部門資料(ID.Value);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dept = repo.Get單一筆部門資料(id.Value);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }
        [HttpPost]
        public ActionResult Delete(int ID, Department department)
        {
            var item = repo.Get單一筆部門資料(ID);
            repo.Delete(item);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");

        }

    }
}