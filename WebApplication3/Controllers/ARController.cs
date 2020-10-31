using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class ARController : Controller
    {
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
    }
}