using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbastillasCRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new List<UserAccount>();
            using (var db = new CRUDEntities2())
            {
                list = db.UserAccount.ToList();
            }
                return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(UserAccount s)
        {
            using (var db = new CRUDEntities2())
            {
                var newUserAccount = new UserAccount();
                newUserAccount.username = s.username;
                newUserAccount.password = s.password;

                db.UserAccount.Add(newUserAccount);
                db.SaveChanges();

                TempData["msg"] = $"Added {newUserAccount.username} successfully!";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var s = new UserAccount();
            using (var db = new CRUDEntities2())
            {
                s = db.UserAccount.Find(id);
            }
            return View(s);
        }
        [HttpPost]
        public ActionResult Update(UserAccount s)
        {
            using (var db = new CRUDEntities2())
            {
                var newUserAccount = db.UserAccount.Find(s.id);
                newUserAccount.username = s.username;
                newUserAccount.password = s.password;
                
                db.SaveChanges();

                TempData["msg"] = $"Updated {newUserAccount.username} successfully!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var s = new UserAccount();
            using (var db = new CRUDEntities2())
            {
                s = db.UserAccount.Find(id);
                db.UserAccount.Remove(s);
              
                db.SaveChanges();

                TempData["msg"] = $"Deleted {s.username} successfully!";
            }
            return RedirectToAction("Index");
        }
    }
    
}