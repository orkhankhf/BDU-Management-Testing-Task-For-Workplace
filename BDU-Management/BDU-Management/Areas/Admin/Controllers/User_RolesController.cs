using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDU_Management.Models;

namespace BDU_Management.Areas.Admin.Controllers
{
    public class User_RolesController : Controller
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/User_Roles
        public ActionResult Index()
        {
            return View(db.User_Roles.ToList());
        }

        // GET: Admin/User_Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Roles user_Roles = db.User_Roles.Find(id);
            if (user_Roles == null)
            {
                return HttpNotFound();
            }
            return View(user_Roles);
        }

        // GET: Admin/User_Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User_Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_role_id,user_role_name")] User_Roles user_Roles)
        {
            if (ModelState.IsValid)
            {
                db.User_Roles.Add(user_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_Roles);
        }

        // GET: Admin/User_Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Roles user_Roles = db.User_Roles.Find(id);
            if (user_Roles == null)
            {
                return HttpNotFound();
            }
            return View(user_Roles);
        }

        // POST: Admin/User_Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_role_id,user_role_name")] User_Roles user_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Roles);
        }

        // GET: Admin/User_Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Roles user_Roles = db.User_Roles.Find(id);
            if (user_Roles == null)
            {
                return HttpNotFound();
            }
            return View(user_Roles);
        }

        // POST: Admin/User_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Roles user_Roles = db.User_Roles.Find(id);
            db.User_Roles.Remove(user_Roles);
            db.SaveChanges();
            return RedirectToAction("Index");
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
