using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakeryMVC.Controllers
{
    /// <summary>
    /// I only changed the ViewBag messages in this controller
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aways Fresh since 1990";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Email us at bakery@gmail.com.";

            return View();
        }
    }
}