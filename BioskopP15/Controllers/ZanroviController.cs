using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BioskopP15.Models;

namespace BioskopP15.Controllers
{
    public class ZanroviController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zanrovi
        public ActionResult Index()
        {
            return View(db.Zanrovi.ToList());
        }

        // GET: Zanrovi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zanr zanr = db.Zanrovi.Find(id);
            if (zanr == null)
            {
                return HttpNotFound();
            }
            return View(zanr);
        }

        // GET: Zanrovi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zanrovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZanrId,Naziv")] Zanr zanr)
        {
            if (ModelState.IsValid)
            {
                db.Zanrovi.Add(zanr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zanr);
        }

        // GET: Zanrovi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zanr zanr = db.Zanrovi.Find(id);
            if (zanr == null)
            {
                return HttpNotFound();
            }
            return View(zanr);
        }

        // POST: Zanrovi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZanrId,Naziv")] Zanr zanr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zanr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zanr);
        }

        // GET: Zanrovi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zanr zanr = db.Zanrovi.Find(id);
            if (zanr == null)
            {
                return HttpNotFound();
            }
            return View(zanr);
        }

        // POST: Zanrovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zanr zanr = db.Zanrovi.Find(id);
            db.Zanrovi.Remove(zanr);
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
