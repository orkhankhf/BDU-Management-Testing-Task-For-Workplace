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
    public class ProfessionsController : Controller
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Professions
        public ActionResult Index()
        {
            var professions = db.Professions.Include(p => p.Cafedra).Include(p => p.Profession_Types);
            return View(professions.ToList());
        }

        // GET: Admin/Professions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // GET: Admin/Professions/Create
        public ActionResult Create()
        {
            ViewBag.profession_cafedra_id = new SelectList(db.Cafedras, "cafedra_id", "cafedra_name");
            ViewBag.profession_profession_type_id = new SelectList(db.Profession_Types, "profession_type_id", "profession_type_name");
            return View();
        }

        // POST: Admin/Professions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "profession_id,profession_name,profession_profession_type_id,profession_cafedra_id")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Professions.Add(profession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.profession_cafedra_id = new SelectList(db.Cafedras, "cafedra_id", "cafedra_name", profession.profession_cafedra_id);
            ViewBag.profession_profession_type_id = new SelectList(db.Profession_Types, "profession_type_id", "profession_type_name", profession.profession_profession_type_id);
            return View(profession);
        }

        // GET: Admin/Professions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            ViewBag.profession_cafedra_id = new SelectList(db.Cafedras, "cafedra_id", "cafedra_name", profession.profession_cafedra_id);
            ViewBag.profession_profession_type_id = new SelectList(db.Profession_Types, "profession_type_id", "profession_type_name", profession.profession_profession_type_id);
            return View(profession);
        }

        // POST: Admin/Professions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "profession_id,profession_name,profession_profession_type_id,profession_cafedra_id")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.profession_cafedra_id = new SelectList(db.Cafedras, "cafedra_id", "cafedra_name", profession.profession_cafedra_id);
            ViewBag.profession_profession_type_id = new SelectList(db.Profession_Types, "profession_type_id", "profession_type_name", profession.profession_profession_type_id);
            return View(profession);
        }

        // GET: Admin/Professions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // POST: Admin/Professions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profession profession = db.Professions.Find(id);
            db.Professions.Remove(profession);
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
