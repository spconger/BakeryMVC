using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryMVC.Models
{
    public class NewPerson
    {
        /// <summary>
        /// the only reason you need this class
        /// is to be able to pass a plain password
        /// to the stored procedure
        /// </summary>
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string Email { set; get;}
        public string Phone { set; get; }
        public string Password { set; get; }
    }
}