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
    public class Teachers_Subjects_PivotController : Controller
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Teachers_Subjects_Pivot
        public ActionResult Index()
        {
            var teachers_Subjects_Pivot = db.Teachers_Subjects_Pivot.Include(t => t.Subject).Include(t => t.Teacher);
            return View(teachers_Subjects_Pivot.ToList());
        }

        // GET: Admin/Teachers_Subjects_Pivot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers_Subjects_Pivot teachers_Subjects_Pivot = db.Teachers_Subjects_Pivot.Find(id);
            if (teachers_Subjects_Pivot == null)
            {
                return HttpNotFound();
            }
            return View(teachers_Subjects_Pivot);
        }

        // GET: Admin/Teachers_Subjects_Pivot/Create
        public ActionResult Create()
        {
            ViewBag.ts_subject_id = new SelectList(db.Subjects, "subject_id", "subject_name");
            ViewBag.ts_teacher_id = new SelectList((from t in db.Teachers select new { t.teacher_id, teacher_fullname = t.teacher_name + " " + t.teacher_surname }), "teacher_id", "teacher_fullname", null);
            return View();
        }

        // POST: Admin/Teachers_Subjects_Pivot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ts_id,ts_teacher_id,ts_subject_id")] Teachers_Subjects_Pivot teachers_Subjects_Pivot)
        {
            if (ModelState.IsValid)
            {
                db.Teachers_Subjects_Pivot.Add(teachers_Subjects_Pivot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ts_subject_id = new SelectList(db.Subjects, "subject_id", "subject_name", teachers_Subjects_Pivot.ts_subject_id);
            ViewBag.ts_teacher_id = new SelectList((from t in db.Teachers select new { t.teacher_id, teacher_fullname = t.teacher_name + " " + t.teacher_surname }), "teacher_id", "teacher_fullname", null);
            return View(teachers_Subjects_Pivot);
        }

        // GET: Admin/Teachers_Subjects_Pivot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers_Subjects_Pivot teachers_Subjects_Pivot = db.Teachers_Subjects_Pivot.Find(id);
            if (teachers_Subjects_Pivot == null)
            {
                return HttpNotFound();
            }
            ViewBag.ts_subject_id = new SelectList(db.Subjects, "subject_id", "subject_name", teachers_Subjects_Pivot.ts_subject_id);
            ViewBag.ts_teacher_id = new SelectList((from t in db.Teachers select new { t.teacher_id, teacher_fullname = t.teacher_name + " " + t.teacher_surname }), "teacher_id", "teacher_fullname", null);
            return View(teachers_Subjects_Pivot);
        }

        // POST: Admin/Teachers_Subjects_Pivot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ts_id,ts_teacher_id,ts_subject_id")] Teachers_Subjects_Pivot teachers_Subjects_Pivot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachers_Subjects_Pivot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ts_subject_id = new SelectList(db.Subjects, "subject_id", "subject_name", teachers_Subjects_Pivot.ts_subject_id);
            ViewBag.ts_teacher_id = new SelectList((from t in db.Teachers select new { t.teacher_id, teacher_fullname = t.teacher_name + " " + t.teacher_surname }), "teacher_id", "teacher_fullname", null);
            return View(teachers_Subjects_Pivot);
        }

        // GET: Admin/Teachers_Subjects_Pivot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers_Subjects_Pivot teachers_Subjects_Pivot = db.Teachers_Subjects_Pivot.Find(id);
            if (teachers_Subjects_Pivot == null)
            {
                return HttpNotFound();
            }
            return View(teachers_Subjects_Pivot);
        }

        // POST: Admin/Teachers_Subjects_Pivot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teachers_Subjects_Pivot teachers_Subjects_Pivot = db.Teachers_Subjects_Pivot.Find(id);
            db.Teachers_Subjects_Pivot.Remove(teachers_Subjects_Pivot);
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
