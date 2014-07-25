using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Business.Models;

namespace E_Business.Controllers
{
    public class ItemsController : Controller
    {
        private ItemDBContext db = new ItemDBContext();

        //
        // GET: /Items/

        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        //
        // GET: /Items/Details/5

        public ActionResult Details(int  id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // GET: /Items/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Items/Create

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            //if (ModelState.IsValid)
            //{
                item.IShopID = "ASD";
                item.IComScore = 2.5;
                item.ISelNum = 0;
                item.IURecNum = 0;
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}

            //return View(item);
        }

        //
        // GET: /Items/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /Items/Edit/5

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /Items/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /Items/Delete/5

        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SearchIndex()
        {
            var items = from m in db.Items
                        select m;
            return View(items);
        }
        [HttpPost]
        public ActionResult SearchIndex(string searchString)
        {
            var items = from m in db.Items
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.IName.Contains(searchString));
            }

            return View(items);
        }
        public ActionResult Purchase(int id = 0)
        {
            if (Request.Cookies["User"] == null)
            {
                return RedirectToAction("Login","Users");
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}