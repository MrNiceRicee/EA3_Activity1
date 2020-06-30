using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestView()
        {
            //return a 'testview.cshtml' - view maps to the action method name
            return View();
        }

        public ActionResult TextInput()
        {
            return View();
        }

        public string Welcome(string Name, int numTimes = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + Name + " Number of Times is " + numTimes);
        }

        public string Welcome2(string Name, int ID = 1)
        {
            if (Name==null || Name.Length<=0)
            {
                return HttpUtility.HtmlEncode("Hello no name is found ID is " + ID);
            }
            return HttpUtility.HtmlEncode("Hello " + Name + " ID is " + ID);
        }

        public string PrintMessage()
        {
            return "<style>h1{font-family: Roboto;} p{font-family: Roboto; } p:hover{color: rgba(45,48,90,.9); font-size: large; transition: font-size 1s; transition-timing-function: ease -in-out;}</style>" +
                "<h1> Welcome!</h1><p> This is the first custom page of the application!</p>";
        }

        public string Hovers()
        {
            return "<style>h1{font-family: Roboto;} p{font-family: Roboto; }" +
                " p:hover{color: rgba(45,48,90,.9); font-size: large; transition: font-size 1s; transition-timing-function: ease -in-out;}" +
                "input[type='text']{transition: width .4s; transition-timing-function: ease -in-out;}" +
                "input[id='userinput']:focus{width: 250px; font-size: 30px}</style>" +
                "<h1> Welcome!</h1>" +
                "<p> Please hover your mouse here</p>"+
                "<input type='text' id ='userinput' name='userinput' placeholder='Enter Text Here' >";

        }
    }
}