using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryMVC.Models;

namespace BakeryMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        /// <summary>
        /// This controller is really no different
        /// than the login controller we did in class
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="userName, password")]LoginClass l)
        {
            BakeryEntities db = new BakeryEntities();

            //use the stored procedure to validate the user
            int result = db.usp_Login(l.userName, l.password);

            //Initialize the Message object
            Message msg = new Message();
            //if the login is valid get the personkey for the user
            if(result != -1)
            {
                var userkey = (from p in db.People
                               where p.PersonEmail.Equals(l.userName)
                               select p.PersonKey).FirstOrDefault();

                int pkey = (int)userkey;
                //write the personkey to a session
                Session["PersonKey"] = pkey;

                //Create the welcome message
                msg.MessageText = "Welcome, " + l.userName;

            }
            else
            {
                //if not valid send the the invalid login message
                msg.MessageText = "Invalid Login";
            }

            return View("Result", msg);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}