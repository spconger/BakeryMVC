using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryMVC.Models;

namespace BakeryMVC.Controllers
{
    /// <summary>
    /// The one thing I did in this class is that 
    /// I went beyond simply checking the Personkey
    /// and checked to see if the person key
    /// belonged to an employee
    /// </summary>
    public class NewProductController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        // GET: NewProduct
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message msg = new Message();
                msg.MessageText = "You must be logged in as an employee to add Products";
                return RedirectToAction("Result", msg);
            }
            if(Session["PersonKey"] != null)
            {
                //this runs a query to see if the personkey
                //matches a personkey in Employee
                int key = (int)Session["PersonKey"];
                var emp = (from e in db.Employees
                           where e.PersonKey == key
                           select e.PersonKey).FirstOrDefault();
                if(emp ==null)
                {
                    //if not it gives this message
                    Message msg = new Message();
                    msg.MessageText = "You must be logged in as an employee to add Products";
                    return RedirectToAction("Result", msg);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="ProductName, ProductPrice")]Product p)
        {
            //add new product
            db.Products.Add(p);
            db.SaveChanges();
            Message msg = new Message();
            msg.MessageText = "Product was added";
            return View("Result", msg);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}