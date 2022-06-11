using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddOrEdit(int id=0)
        {

            UserRegi userModel = new UserRegi();

            return View(userModel);
        }


        [HttpPost]

        public ActionResult AddOrEddit(UserRegi userModel)
        {
            using(ConnectionString connection = new ConnectionString())
            {
                
                if(connection.UserRegis.Any(x=> x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exists";
                    return View("AddOrEdit", userModel);
                }

                connection.UserRegis.Add(userModel);
                connection.SaveChanges();

                
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return View("AddOrEdit", new UserRegi());
           
        }
    }
}