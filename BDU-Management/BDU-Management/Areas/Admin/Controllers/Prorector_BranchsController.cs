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
    public class Prorector_BranchsController : Controller
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Prorector_Branchs
        public ActionResult Index()
        {
            var prorector_Branchs = db.Prorector_Branchs.Include(p => p.Authorized_Persons);
            return View(prorector_Branchs.ToList());
        }

        // GET: Admin/Prorector_Branchs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prorector_Branchs prorector_Branchs = db.Prorector_Branchs.Find(id);
            if (prorector_Branchs == null)
            {
                return HttpNotFound();
            }
            return View(prorector_Branchs);
        }

        // GET: Admin/Prorector_Branchs/Create
        public ActionResult Create()
        {
            
            ViewBag.prorector_branch_prorector_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Prorektor")
                                                                    select new
                                                                    {
                                                                        c.authorized_person_id,
                                                                        authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname
                                                                    }), "authorized_person_id", "authorized_person_fullname", null);
            return View();
        }

        // POST: Admin/Prorector_Branchs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prorector_branch_id,prorector_branch_name,prorector_branch_prorector_id")] Prorector_Branchs prorector_Branchs)
        {
            if (ModelState.IsValid)
            {
                db.Prorector_Branchs.Add(prorector_Branchs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.prorector_branch_prorector_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Prorektor")
                                                                    select new
                                                                    {
                                                                        c.authorized_person_id,
                                                                        authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname
                                                                    }), "authorized_person_id", "authorized_person_fullname", null);
            return View(prorector_Branchs);
        }

        // GET: Admin/Prorector_Branchs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prorector_Branchs prorector_Branchs = db.Prorector_Branchs.Find(id);
            if (prorector_Branchs == null)
            {
                return HttpNotFound();
            }
            ViewBag.prorector_branch_prorector_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Prorektor")
                                                                    select new
                                                                    {
                                                                        c.authorized_person_id,
                                                                        authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname
                                                                    }), "authorized_person_id", "authorized_person_fullname", null);
            return View(prorector_Branchs);
        }

        // POST: Admin/Prorector_Branchs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prorector_branch_id,prorector_branch_name,prorector_branch_prorector_id")] Prorector_Branchs prorector_Branchs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prorector_Branchs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.prorector_branch_prorector_id = new SelectList((from c in db.Authorized_Persons.Where(a => a.User_Roles.user_role_name == "Prorektor")
                                                                    select new
                                                                    {
                                                                        c.authorized_person_id,
                                                                        authorized_person_fullname = c.authorized_person_name + " " + c.authorized_person_surname
                                                                    }), "authorized_person_id", "authorized_person_fullname", null);
            return View(prorector_Branchs);
        }

        // GET: Admin/Prorector_Branchs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prorector_Branchs prorector_Branchs = db.Prorector_Branchs.Find(id);
            if (prorector_Branchs == null)
            {
                return HttpNotFound();
            }
            return View(prorector_Branchs);
        }

        // POST: Admin/Prorector_Branchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prorector_Branchs prorector_Branchs = db.Prorector_Branchs.Find(id);
            db.Prorector_Branchs.Remove(prorector_Branchs);
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
