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
    public class CafedrasController : Controller
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Cafedras
        public ActionResult Index()
        {
            var cafedras = db.Cafedras.Include(c => c.Authorized_Persons).Include(c => c.Faculty);
            return View(cafedras.ToList());
        }

        // GET: Admin/Cafedras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafedra cafedra = db.Cafedras.Find(id);
            if (cafedra == null)
            {
                return HttpNotFound();
            }
            return View(cafedra);
        }

        // GET: Admin/Cafedras/Create
        public ActionResult Create()
        {
            ViewBag.cafedra_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Kafedra Müdiri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            ViewBag.cafedra_faculty_id = new SelectList(db.Faculties, "faculty_id", "faculty_name");
            return View();
        }

        // POST: Admin/Cafedras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cafedra_id,cafedra_name,cafedra_chief_id,cafedra_faculty_id")] Cafedra cafedra)
        {
            if (ModelState.IsValid)
            {
                db.Cafedras.Add(cafedra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cafedra_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Kafedra Müdiri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            ViewBag.cafedra_faculty_id = new SelectList(db.Faculties, "faculty_id", "faculty_name", cafedra.cafedra_faculty_id);
            return View(cafedra);
        }

        // GET: Admin/Cafedras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafedra cafedra = db.Cafedras.Find(id);
            if (cafedra == null)
            {
                return HttpNotFound();
            }
            ViewBag.cafedra_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Kafedra Müdiri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            ViewBag.cafedra_faculty_id = new SelectList(db.Faculties, "faculty_id", "faculty_name", cafedra.cafedra_faculty_id);
            return View(cafedra);
        }

        // POST: Admin/Cafedras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cafedra_id,cafedra_name,cafedra_chief_id,cafedra_faculty_id")] Cafedra cafedra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cafedra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cafedra_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Kafedra Müdiri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            ViewBag.cafedra_faculty_id = new SelectList(db.Faculties, "faculty_id", "faculty_name", cafedra.cafedra_faculty_id);
            return View(cafedra);
        }

        // GET: Admin/Cafedras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cafedra cafedra = db.Cafedras.Find(id);
            if (cafedra == null)
            {
                return HttpNotFound();
            }
            return View(cafedra);
        }

        // POST: Admin/Cafedras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cafedra cafedra = db.Cafedras.Find(id);
            db.Cafedras.Remove(cafedra);
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
