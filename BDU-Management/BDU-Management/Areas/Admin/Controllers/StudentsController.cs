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
    public class StudentsController : BaseController_Abstract
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Gender).Include(s => s.Profession);
            return View(students.ToList());
        }

        // GET: Admin/Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Admin/Students/Create
        public ActionResult Create()
        {
            ViewBag.student_gender_id = new SelectList(db.Genders, "gender_id", "gender_name");
            ViewBag.student_profession_id = new SelectList(db.Professions, "profession_id", "profession_name");
            return View();
        }

        // POST: Admin/Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "student_id,student_name,student_surname,student_father_name,student_email,student_password,student_gender_id,student_profession_id")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.student_password = PasswordStorage.CreateHash(student.student_password);
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.student_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", student.student_gender_id);
            ViewBag.student_profession_id = new SelectList(db.Professions, "profession_id", "profession_name", student.student_profession_id);
            return View(student);
        }

        // GET: Admin/Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.student_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", student.student_gender_id);
            ViewBag.student_profession_id = new SelectList(db.Professions, "profession_id", "profession_name", student.student_profession_id);
            return View(student);
        }

        // POST: Admin/Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "student_id,student_name,student_surname,student_father_name,student_email,student_password,student_gender_id,student_profession_id")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.student_password = PasswordStorage.CreateHash(student.student_password);
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.student_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", student.student_gender_id);
            ViewBag.student_profession_id = new SelectList(db.Professions, "profession_id", "profession_name", student.student_profession_id);
            return View(student);
        }

        // GET: Admin/Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
