using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch2_PartyInvites.Models;

namespace Ch2_PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       /* public ActionResult Index()
        {
            return View();
        }  */
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning": "Good afternoon";
            return View();
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid) { 
            return View("Thanks",guestResponse);
            }
            else
            {
                return View();
            }
        }
    }
}