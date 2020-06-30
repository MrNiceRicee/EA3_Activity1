using LoginApp.Models;
using LoginApp.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(UserModel userModel)
        {
            //call the security business service Authenticate() method from the login() method
            //and save the results of the method call i hte local method variable
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);
            if (success)
            {
                //return"<h1>Login Success!<h1> <p style='font-family: Roboto'> Welcome, "+userModel.Username+" your password is "+userModel.Password +"</p>";
                return View("LoginSuccess", userModel);
            }
            else
            {
                //return "<h1 style='color: red'> Login Failed </p>";
                return View("LoginFailed");

            }
        }
    }
}