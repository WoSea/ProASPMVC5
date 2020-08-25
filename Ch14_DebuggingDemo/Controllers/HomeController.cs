using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch14_DebuggingDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int firstVal = 10;
            int secondVal = 2;
            int result = firstVal / secondVal;
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View(result+2);
        }

      
    }
}