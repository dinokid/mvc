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
    public class UsersController : Controller
    {
        private UserDBContext db = new UserDBContext();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(string id = null)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(string id = null)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(string id = null)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public User SelectByID(string id)//根据用户id查找用户
        {
            User user = db.Users.Find(id);
            return user;
        }

        public bool InsertSurfRecord(string UID, string IID)//插入浏览记录
        {
            User user = db.Users.Find(UID);
            if (user != null)
            {
                //db.Entry(user).State = EntityState.Modified;
                int i = 0;
                for (; i < 5; i++)
                {
                    if (user.USurfRecord[i] == null)
                        user.USurfRecord[i] = IID;
                }
                if (i == 5)
                {
                    int j;
                    for (j = 0; j < 4; j++)
                        user.USurfRecord[j] = user.USurfRecord[j + 1];
                    user.USurfRecord[4] = IID;
                }
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool InsertCollect(string UID, string IID)//将商品加购物车
        {
            User user = db.Users.Find(UID);
            String[] collect;
            int i;
            if (user != null)
            {
                //db.Entry(user).State = EntityState.Modified;
                if (user.UCollect == null)
                {
                    user.UCollect = new String[10];
                    user.UCollect[0] = IID;
                }
                else if (user.UCollect[user.UCollect.Length] != null)
                {
                    collect = new String[2 * user.UCollect.Length];
                    for (i = 0; i < user.UCollect.Length; i++)
                    {
                        collect[i] = user.UCollect[i];
                    }
                    collect[i] = IID;
                }
                else
                {
                    for (i = 0; i < user.UCollect.Length; i++)
                        if (user.UCollect[i] == null)
                        {
                            user.UCollect[i] = IID;
                            break;
                        }
                }
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool InsertShopCart(string UID, string IID)//将商品添加到购物车
        {
            User user = db.Users.Find(UID);
            String[] shopcart;
            int i;
            if (user != null)
            {
                //db.Entry(user).State = EntityState.Modified;
                if (user.UShopCart == null)
                {
                    user.UShopCart = new String[10];
                    user.UShopCart[0] = IID;
                }
                else if (user.UCollect[user.UShopCart.Length] != null)
                {
                    shopcart = new String[2 * user.UShopCart.Length];
                    for (i = 0; i < user.UShopCart.Length; i++)
                    {
                        shopcart[i] = user.UShopCart[i];
                    }
                    shopcart[i] = IID;
                }
                else
                {
                    for (i = 0; i < user.UShopCart.Length; i++)
                        if (user.UShopCart[i] == null)
                        {
                            user.UShopCart[i] = IID;
                            break;
                        }
                }
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ClearSurfRecord(String UID)//清空浏览记录
        {
            User user = db.Users.Find(UID);
            if (user != null)
            {
                for (int i = 0; i < user.USurfRecord.Length; i++)
                    user.USurfRecord[i] = null;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCollect(String UID, String IID)//取消收藏
        {
            int i;
            User user = db.Users.Find(UID);
            if (user != null)
            {
                for (i = 0; i < user.UCollect.Length; i++)
                    if (user.UCollect[i] == IID)
                        break;
                while (i < user.UCollect.Length - 1 && user.UCollect[i + 1] != null)
                    user.UCollect[i] = user.UCollect[i + 1];
                user.UCollect[i] = null;
                return true;
            }
            return false;
        }

        public bool DeleteShopCart(String UID, String IID)//取消收藏
        {
            int i;
            User user = db.Users.Find(UID);
            if (user != null)
            {
                for (i = 0; i < user.UShopCart.Length; i++)
                    if (user.UShopCart[i] == IID)
                        break;
                while (i < user.UShopCart.Length - 1 && user.UShopCart[i + 1] != null)
                    user.UShopCart[i] = user.UShopCart[i + 1];
                user.UShopCart[i] = null;
                return true;
            }
            return false;
        }
    }
}