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
    public class Authorized_PersonsController : BaseController_Abstract
    {
        private BDU_ManagementEntities db = new BDU_ManagementEntities();

        // GET: Admin/Authorized_Persons
        public ActionResult Index()
        {
            var authorized_Persons = db.Authorized_Persons.Include(a => a.Degree).Include(a => a.Gender).Include(a => a.User_Roles);
            return View(authorized_Persons.ToList());
        }

        // GET: Admin/Authorized_Persons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorized_Persons authorized_Persons = db.Authorized_Persons.Find(id);
            if (authorized_Persons == null)
            {
                return HttpNotFound();
            }
            return View(authorized_Persons);
        }

        // GET: Admin/Authorized_Persons/Create
        public ActionResult Create()
        {
            ViewBag.authorized_person_degree_id = new SelectList(db.Degrees, "degree_id", "degree_name");
            ViewBag.authorized_person_gender_id = new SelectList(db.Genders, "gender_id", "gender_name");
            ViewBag.authorized_person_role_id = new SelectList(db.User_Roles, "user_role_id", "user_role_name");
            return View();
        }

        // POST: Admin/Authorized_Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "authorized_person_id,authorized_person_name,authorized_person_surname,authorized_person_father_name,authorized_person_email,authorized_person_password,authorized_person_role_id,authorized_person_degree_id,authorized_person_gender_id")] Authorized_Persons authorized_Persons)
        {
            if (ModelState.IsValid)
            {
                authorized_Persons.authorized_person_password = PasswordStorage.CreateHash(authorized_Persons.authorized_person_password);
                db.Authorized_Persons.Add(authorized_Persons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorized_person_degree_id = new SelectList(db.Degrees, "degree_id", "degree_name", authorized_Persons.authorized_person_degree_id);
            ViewBag.authorized_person_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", authorized_Persons.authorized_person_gender_id);
            ViewBag.authorized_person_role_id = new SelectList(db.User_Roles, "user_role_id", "user_role_name", authorized_Persons.authorized_person_role_id);
            return View(authorized_Persons);
        }

        // GET: Admin/Authorized_Persons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorized_Persons authorized_Persons = db.Authorized_Persons.Find(id);
            if (authorized_Persons == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorized_person_degree_id = new SelectList(db.Degrees, "degree_id", "degree_name", authorized_Persons.authorized_person_degree_id);
            ViewBag.authorized_person_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", authorized_Persons.authorized_person_gender_id);
            ViewBag.authorized_person_role_id = new SelectList(db.User_Roles, "user_role_id", "user_role_name", authorized_Persons.authorized_person_role_id);
            return View(authorized_Persons);
        }

        // POST: Admin/Authorized_Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "authorized_person_id,authorized_person_name,authorized_person_surname,authorized_person_father_name,authorized_person_email,authorized_person_password,authorized_person_role_id,authorized_person_degree_id,authorized_person_gender_id")] Authorized_Persons authorized_Persons)
        {
            if (ModelState.IsValid)
            {
                authorized_Persons.authorized_person_password = PasswordStorage.CreateHash(authorized_Persons.authorized_person_password);
                db.Entry(authorized_Persons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorized_person_degree_id = new SelectList(db.Degrees, "degree_id", "degree_name", authorized_Persons.authorized_person_degree_id);
            ViewBag.authorized_person_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", authorized_Persons.authorized_person_gender_id);
            ViewBag.authorized_person_role_id = new SelectList(db.User_Roles, "user_role_id", "user_role_name", authorized_Persons.authorized_person_role_id);
            return View(authorized_Persons);
        }

        // GET: Admin/Authorized_Persons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorized_Persons authorized_Persons = db.Authorized_Persons.Find(id);
            if (authorized_Persons == null)
            {
                return HttpNotFound();
            }
            return View(authorized_Persons);
        }

        // POST: Admin/Authorized_Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authorized_Persons authorized_Persons = db.Authorized_Persons.Find(id);
            db.Authorized_Persons.Remove(authorized_Persons);
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
