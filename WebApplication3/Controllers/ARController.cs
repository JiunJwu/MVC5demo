using Newtonsoft.Json;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ARController : Controller
    {
        DepartmentRepository repo;

        public ARController()
        {
            repo = RepositoryHelper.GetDepartmentRepository();
        }
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewTest2()
        {
            return View("Index");
        }
        public ActionResult ViewTest3()
        {
            return View("TEMP");
        }
        public ActionResult ViewTest4()
        {
            return PartialView("Index");
        }
        public ActionResult JsonTest()
        {
            repo.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
            var data = repo.Get單一筆部門資料(1);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult JsonTest2()
        {
            var data = repo.Get單一筆部門資料(1);

            return Json(data);
        }
        public ActionResult JsonTest3()
        {
            var data = repo.Get單一筆部門資料(1);
            Response.ContentType = "text/json";
            return Content(JsonConvert.SerializeObject(data));
        }
        public ActionResult JsonTest4()
        {
            var data = repo.Get單一筆部門資料(1);
            var result = new DepartmentJson();
            result.InjectFrom(data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}