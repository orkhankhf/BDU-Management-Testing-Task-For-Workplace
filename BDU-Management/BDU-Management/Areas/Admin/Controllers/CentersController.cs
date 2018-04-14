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
    public class CentersController : Controller
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Centers
        public ActionResult Index()
        {
            var centers = db.Centers.Include(c => c.Authorized_Persons);
            return View(centers.ToList());
        }

        // GET: Admin/Centers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = db.Centers.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }

        // GET: Admin/Centers/Create
        public ActionResult Create()
        {
            ViewBag.center_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a=>a.User_Roles.user_role_name=="Mərkəz Rəhbəri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View();
        }

        // POST: Admin/Centers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "center_id,center_name,center_chief_id")] Center center)
        {
            if (ModelState.IsValid)
            {
                db.Centers.Add(center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.center_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Mərkəz Rəhbəri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View(center);
        }

        // GET: Admin/Centers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = db.Centers.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            ViewBag.center_chief_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Mərkəz Rəhbəri") select new { c.authorized_person_id, authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname }), "authorized_person_id", "authorized_person_fullname", null);
            return View(center);
        }

        // POST: Admin/Centers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "center_id,center_name,center_chief_id")] Center center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.center_chief_id = new SelectList(db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Mərkəz Rəhbəri"), "authorized_person_id", "authorized_person_name", center.center_chief_id);
            return View(center);
        }

        // GET: Admin/Centers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Center center = db.Centers.Find(id);
            if (center == null)
            {
                return HttpNotFound();
            }
            return View(center);
        }

        // POST: Admin/Centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Center center = db.Centers.Find(id);
            db.Centers.Remove(center);
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
