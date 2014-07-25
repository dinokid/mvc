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
    public class OrdersController : Controller
    {
        private OrderDBContext db = new OrderDBContext();
        private ItemDBContext ItemDb = new ItemDBContext();
        private UserDBContext UserDb = new UserDBContext();
        //
        // GET: /Orders/

        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        //
        // GET: /Orders/Details/5

        public ActionResult Details(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // GET: /Orders/Create

        //public ActionResult Create()
        //{
        //    var mailList = new List<String>();
        //    mailList.Add("EMS");
        //    mailList.Add("SF");
        //    mailList.Add("YT");
        //    mailList.Add("PY");
        //    ViewBag.mailing = new SelectList(mailList);
        //    return View();
        //}

        ////
        //// POST: /Orders/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(String userId, int itemId, uint number = 1)
        {
            User buyer = UserDb.Users.Find(userId);
            Item merchandise = ItemDb.Items.Find(itemId);
            User seller = UserDb.Users.Find(merchandise.IShopID);
            Order order = new Order();

            order.IID = itemId;
            order.BID = userId;
            order.SID = merchandise.IShopID;
            order.ItemNumber = number;
            order.Mailmanner = MailManner.EMS;
            order.MailPrice = 0;
            order.Discout = 0;
            order.FPrice = merchandise.IPrice * number;
            //order.SAddress = seller.UAd;
            order.RAddress = buyer.UAd;
            //order.SelName = seller.UName;
            order.RecName = buyer.UName;
            //order.SelPhone = seller.UPhone;
            order.RecPhone = buyer.UPhone;
            order.State = OrderState.UnSend;


            var mailList = new List<String>();
            mailList.Add("EMS");
            mailList.Add("SF");
            mailList.Add("YT");
            mailList.Add("PY");
            ViewBag.mailing = new SelectList(mailList);

            ViewBag.itemName = merchandise.IName;
            ViewBag.singleItemPrice = merchandise.IPrice;
            ViewBag.number = number;
            ViewBag.totalPrice = merchandise.IPrice * number;
            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        //
        // GET: /Orders/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Orders/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        //
        // GET: /Orders/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Orders/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}