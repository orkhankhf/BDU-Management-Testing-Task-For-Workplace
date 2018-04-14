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
    public class MuseumsController : Controller
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Museums
        public ActionResult Index()
        {
            var museums = db.Museums.Include(m => m.Authorized_Persons);
            return View(museums.ToList());
        }

        // GET: Admin/Museums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.Museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }

        // GET: Admin/Museums/Create
        public ActionResult Create()
        {
            ViewBag.museum_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Muzey Rəhbəri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View();
        }

        // POST: Admin/Museums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "museum_id,museum_name,museum_chief_id")] Museum museum)
        {
            if (ModelState.IsValid)
            {
                db.Museums.Add(museum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.museum_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Muzey Rəhbəri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View(museum);
        }

        // GET: Admin/Museums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.Museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            ViewBag.museum_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Muzey Rəhbəri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View(museum);
        }

        // POST: Admin/Museums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "museum_id,museum_name,museum_chief_id")] Museum museum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(museum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.museum_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Muzey Rəhbəri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View(museum);
        }

        // GET: Admin/Museums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.Museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }

        // POST: Admin/Museums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Museum museum = db.Museums.Find(id);
            db.Museums.Remove(museum);
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
