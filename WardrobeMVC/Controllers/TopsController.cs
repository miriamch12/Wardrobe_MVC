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
    public class TopsController : Controller
    {
        private WardrobeMVCContext db = new WardrobeMVCContext();

        // GET: Tops
        public ActionResult Index()
        {
            var tops = db.Tops.Include(t => t.Color).Include(t => t.Occasion).Include(t => t.Season);
            return View(tops.ToList());
        }

        // GET: Tops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Top top = db.Tops.Find(id);
            if (top == null)
            {
                return HttpNotFound();
            }
            return View(top);
        }

        // GET: Tops/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName");
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName");
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName");
            return View();
        }

        // POST: Tops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopId,TopName,TopPhoto,ColorId,SeasonId,OccasionId")] Top top)
        {
            if (ModelState.IsValid)
            {
                db.Tops.Add(top);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName", top.ColorId);
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName", top.OccasionId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName", top.SeasonId);
            return View(top);
        }

        // GET: Tops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Top top = db.Tops.Find(id);
            if (top == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName", top.ColorId);
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName", top.OccasionId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName", top.SeasonId);
            return View(top);
        }

        // POST: Tops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopId,TopName,TopPhoto,ColorId,SeasonId,OccasionId")] Top top)
        {
            if (ModelState.IsValid)
            {
                db.Entry(top).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "ColorName", top.ColorId);
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "OccasionName", top.OccasionId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonName", top.SeasonId);
            return View(top);
        }

        // GET: Tops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Top top = db.Tops.Find(id);
            if (top == null)
            {
                return HttpNotFound();
            }
            return View(top);
        }

        // POST: Tops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Top top = db.Tops.Find(id);
            db.Tops.Remove(top);
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
