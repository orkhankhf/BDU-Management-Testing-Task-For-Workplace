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
    public class FacultiesController : Controller
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Faculties
        public ActionResult Index()
        {
            var faculties = db.Faculties.Include(f => f.Authorized_Persons);
            return View(faculties.ToList());
        }

        // GET: Admin/Faculties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // GET: Admin/Faculties/Create
        public ActionResult Create()
        {
            ViewBag.faculty_dean_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Dekan") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View();
        }

        // POST: Admin/Faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "faculty_id,faculty_name,faculty_dean_id")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Faculties.Add(faculty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.faculty_dean_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Dekan") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View(faculty);
        }

        // GET: Admin/Faculties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            ViewBag.faculty_dean_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Dekan") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View(faculty);
        }

        // POST: Admin/Faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "faculty_id,faculty_name,faculty_dean_id")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.faculty_dean_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Dekan") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View(faculty);
        }

        // GET: Admin/Faculties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Admin/Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            db.Faculties.Remove(faculty);
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
