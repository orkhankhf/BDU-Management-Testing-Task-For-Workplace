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
    public class Profession_TypesController : Controller
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Profession_Types
        public ActionResult Index()
        {
            return View(db.Profession_Types.ToList());
        }

        // GET: Admin/Profession_Types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession_Types profession_Types = db.Profession_Types.Find(id);
            if (profession_Types == null)
            {
                return HttpNotFound();
            }
            return View(profession_Types);
        }

        // GET: Admin/Profession_Types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Profession_Types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "profession_type_id,profession_type_name")] Profession_Types profession_Types)
        {
            if (ModelState.IsValid)
            {
                db.Profession_Types.Add(profession_Types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profession_Types);
        }

        // GET: Admin/Profession_Types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession_Types profession_Types = db.Profession_Types.Find(id);
            if (profession_Types == null)
            {
                return HttpNotFound();
            }
            return View(profession_Types);
        }

        // POST: Admin/Profession_Types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "profession_type_id,profession_type_name")] Profession_Types profession_Types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profession_Types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profession_Types);
        }

        // GET: Admin/Profession_Types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession_Types profession_Types = db.Profession_Types.Find(id);
            if (profession_Types == null)
            {
                return HttpNotFound();
            }
            return View(profession_Types);
        }

        // POST: Admin/Profession_Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profession_Types profession_Types = db.Profession_Types.Find(id);
            db.Profession_Types.Remove(profession_Types);
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
