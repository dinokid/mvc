using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Business.Models;
using System.Data.Entity;

namespace E_Business.Controllers
{
    public class HomeController : Controller
    {
        private ItemDBContext db = new ItemDBContext();
        public ActionResult Index()
        {
            var items = from m in db.Items
                           orderby m.IComScore descending
                           select m;
           return View(items);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
