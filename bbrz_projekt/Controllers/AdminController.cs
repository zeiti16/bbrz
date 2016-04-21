using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bbrz_projekt.Data;
using bbrz_projekt.ViewModels;

namespace bbrz_projekt.Controllers
{
    public class AdminController : Controller
    {
        private igdbDB db = new igdbDB();

        // GET: Admin
        [Authorize]
        public ActionResult Start()
        {
            if (Verify.IsUserAdmin(User.Identity.Name))
                return View(db.tblUser.ToList());
            else
                return RedirectToAction("Index", "Home");
        }

        // GET: Admin/Create
        [Authorize]
        public ActionResult Create()
        {
            if (Verify.IsUserAdmin(User.Identity.Name))
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        // POST: Admin/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Firstname,Lastname,Password,Administrator,Gesperrt")] tblUser tblUser)
        {
            if (Verify.IsUserAdmin(User.Identity.Name))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.tblUser.Add(tblUser);
                        db.SaveChanges();
                        return RedirectToAction("Start");
                    }
                }
                catch
                {

                }
                return View(tblUser);
            } else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Admin/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (Verify.IsUserAdmin(User.Identity.Name))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblUser tblUser = db.tblUser.Find(id);
                if (tblUser == null)
                {
                    return HttpNotFound();
                }
                return View(tblUser);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Admin/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Firstname,Lastname,Administrator,Gesperrt")] tblUser tblUser)
        {
            if (Verify.IsUserAdmin(User.Identity.Name))
            {
                if (ModelState.IsValid)
                {
                    tblUser.Password = db.tblUser.Where(x => x.Username == tblUser.Username).Select(f => f.Password).SingleOrDefault();
                    db.Entry(tblUser).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Start");
                }
                return View(tblUser);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            }

        // GET: Admin/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = db.tblUser.Find(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblUser tblUser = db.tblUser.Find(id);
            db.tblUser.Remove(tblUser);
            db.SaveChanges();
            return RedirectToAction("Start");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
