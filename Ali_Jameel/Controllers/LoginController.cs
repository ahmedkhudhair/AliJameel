using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ali_Jameel.Models;
using Microsoft.AspNetCore.Session;

namespace Ali_Jameel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        [HttpGet]
        public ActionResult SignIn(User user)
        {
            
            Tuple<bool,string> ok = user.SignIn();
            if (ok.Item1)
            {
                System.Web.HttpContext.Current.Session["Username"] = ok.Item2;
                //TempData["Username"] = ok.Item2;
                return RedirectToAction("news", "Home");
            }
            else
            {
                TempData["Message"] = "Faild";
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            bool exception = false;
            try
            {
                user.SignUp();
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                exception = true;
            }

            if (!exception)
            {
                TempData["Message"] = "Rigestered";
            }

            return RedirectToAction("index", "Login");
        }

    }
}