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
    public class TeachersController : BaseController_Abstract
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Teachers
        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(t => t.Gender);
            return View(teachers.ToList());
        }

        // GET: Admin/Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Admin/Teachers/Create
        public ActionResult Create()
        {
            ViewBag.teacher_gender_id = new SelectList(db.Genders, "gender_id", "gender_name");
            return View();
        }

        // POST: Admin/Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "teacher_id,teacher_name,teacher_surname,teacher_father_name,teacher_email,teacher_password,teacher_gender_id")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.teacher_password = PasswordStorage.CreateHash(teacher.teacher_password);
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teacher_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", teacher.teacher_gender_id);
            return View(teacher);
        }

        // GET: Admin/Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacher_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", teacher.teacher_gender_id);
            return View(teacher);
        }

        // POST: Admin/Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "teacher_id,teacher_name,teacher_surname,teacher_father_name,teacher_email,teacher_password,teacher_gender_id")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.teacher_password = PasswordStorage.CreateHash(teacher.teacher_password);
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teacher_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", teacher.teacher_gender_id);
            return View(teacher);
        }

        // GET: Admin/Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Admin/Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
