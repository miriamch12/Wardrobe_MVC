using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC.Models;

namespace WardrobeMVC.Controllers
{
    public class OccasionsController : Controller
    {
        private WardrobeMVCContext db = new WardrobeMVCContext();

        // GET: Occasions
        public ActionResult Index()
        {
            return View(db.Occasions.ToList());
        }

        // GET: Occasions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occasion occasion = db.Occasions.Find(id);
            if (occasion == null)
            {
                return HttpNotFound();
            }
            return View(occasion);
        }

        // GET: Occasions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Occasions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "occasionID,occasionName")] Occasion occasion)
        {
            if (ModelState.IsValid)
            {
                db.Occasions.Add(occasion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(occasion);
        }

        // GET: Occasions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occasion occasion = db.Occasions.Find(id);
            if (occasion == null)
            {
                return HttpNotFound();
            }
            return View(occasion);
        }

        // POST: Occasions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "occasionID,occasionName")] Occasion occasion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occasion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(occasion);
        }

        // GET: Occasions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occasion occasion = db.Occasions.Find(id);
            if (occasion == null)
            {
                return HttpNotFound();
            }
            return View(occasion);
        }

        // POST: Occasions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Occasion occasion = db.Occasions.Find(id);
            db.Occasions.Remove(occasion);
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
