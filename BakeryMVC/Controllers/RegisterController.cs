using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryMVC.Models;

namespace BakeryMVC.Controllers
{
    /// <summary>
    /// Pretty similar to what we did in class
    /// </summary>
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="LastName, FirstName, Email, Phone, Password")]NewPerson p)
        {
            BakeryEntities db = new BakeryEntities();
            Message msg = new Message();
            int result = db.usp_newPerson(p.LastName, p.FirstName, p.Email, p.Phone, p.Password);
            if(result != -1)
            {
                
                msg.MessageText = "Thank you for registering";
                
            }
            else
            {
                msg.MessageText = "Something went wrong with the registration";
            }

            return View("Result", msg);
        }
        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}