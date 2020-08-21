using Ch3_TestingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch3_TestingDemo.Controllers
{
    public class AdminController : Controller
    {
        private IUserRepository repository;
        public AdminController(IUserRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult ChangeLoginName(string oldName, string newName)
        {
            User user = repository.FetchByLoginName(oldName);
            user.LoginName = newName;
            repository.SubmitChanges();
            return View();
        }
    }
}