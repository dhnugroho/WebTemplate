using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTemplate.Models;

namespace WebTemplate.Controllers
{
    public class MasterController : Controller
    {
        private dbFilesEntities1 db = new dbFilesEntities1();

        // GET: Master
        public ActionResult Index()
        {
            return View(db.tbl_registration.ToList());
        }

        // GET: Master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_registration tbl_registration = db.tbl_registration.Find(id);
            if (tbl_registration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_registration);
        }

        // GET: Master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sr_no,Email,Password,Name,Address,City,Age,Status")] tbl_registration tbl_registration)
        {
            if (ModelState.IsValid)
            {
                db.tbl_registration.Add(tbl_registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_registration);
        }

        // GET: Master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_registration tbl_registration = db.tbl_registration.Find(id);
            if (tbl_registration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_registration);
        }

        // POST: Master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sr_no,Email,Password,Name,Address,City,Age,Status")] tbl_registration tbl_registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_registration);
        }

        // GET: Master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_registration tbl_registration = db.tbl_registration.Find(id);
            if (tbl_registration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_registration);
        }

        // POST: Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_registration tbl_registration = db.tbl_registration.Find(id);
            db.tbl_registration.Remove(tbl_registration);
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
