using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryMVC.Models;

namespace BakeryMVC.Controllers
{
    /// <summary>
    /// Basic contoller, just listing objects
    /// </summary>
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            BakeryEntities db = new BakeryEntities();

            return View(db.Products.ToList());
        }
    }
}