using KSM_Financial_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSM_Financial_API.Controllers
{
    public class HomeController : Controller
    {
        private ApiDbContext db = new ApiDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //public ActionResult TestConnection()
        //{
        //    return View(db.Households.ToList());
        //}
    }
}
