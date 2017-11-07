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
    public class ParticipantsController : Controller
    {
        private dbFilesEntities1 db = new dbFilesEntities1();

        // GET: Participants
        public ActionResult Index()
        {
            return View(db.tb_r_travel_request_participant.ToList());
        }

        // GET: Participants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_r_travel_request_participant tb_r_travel_request_participant = db.tb_r_travel_request_participant.Find(id);
            if (tb_r_travel_request_participant == null)
            {
                return HttpNotFound();
            }
            return View(tb_r_travel_request_participant);
        }

        // GET: Participants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_request_participant,no_reg_parent,group_code,no_reg,allowance_idr,allowance_usd,allowance_jpy,created_date,modified_date,user_modified,active_flag")] tb_r_travel_request_participant tb_r_travel_request_participant)
        {
            if (ModelState.IsValid)
            {
                db.tb_r_travel_request_participant.Add(tb_r_travel_request_participant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_r_travel_request_participant);
        }

        // GET: Participants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_r_travel_request_participant tb_r_travel_request_participant = db.tb_r_travel_request_participant.Find(id);
            if (tb_r_travel_request_participant == null)
            {
                return HttpNotFound();
            }
            return View(tb_r_travel_request_participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_request_participant,no_reg_parent,group_code,no_reg,allowance_idr,allowance_usd,allowance_jpy,created_date,modified_date,user_modified,active_flag")] tb_r_travel_request_participant tb_r_travel_request_participant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_r_travel_request_participant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_r_travel_request_participant);
        }

        // GET: Participants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_r_travel_request_participant tb_r_travel_request_participant = db.tb_r_travel_request_participant.Find(id);
            if (tb_r_travel_request_participant == null)
            {
                return HttpNotFound();
            }
            return View(tb_r_travel_request_participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_r_travel_request_participant tb_r_travel_request_participant = db.tb_r_travel_request_participant.Find(id);
            db.tb_r_travel_request_participant.Remove(tb_r_travel_request_participant);
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
