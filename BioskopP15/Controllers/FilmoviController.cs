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
    public class FilmoviController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Filmovi
        public ActionResult Index()
        {
            var filmovi = db.Filmovi.Include(f => f.Zanr);
            return View(filmovi.ToList());
        }

        // GET: Filmovi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmovi.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Filmovi/Create
        public ActionResult Create()
        {
            ViewBag.ZanrId = new SelectList(db.Zanrovi, "ZanrId", "Naziv");
            return View();
        }

        // POST: Filmovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmId,ZanrId,Naslov,DatumPrikazivanja,Cena")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Filmovi.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ZanrId = new SelectList(db.Zanrovi, "ZanrId", "Naziv", film.ZanrId);
            return View(film);
        }

        // GET: Filmovi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmovi.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZanrId = new SelectList(db.Zanrovi, "ZanrId", "Naziv", film.ZanrId);
            return View(film);
        }

        // POST: Filmovi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmId,ZanrId,Naslov,DatumPrikazivanja,Cena")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZanrId = new SelectList(db.Zanrovi, "ZanrId", "Naziv", film.ZanrId);
            return View(film);
        }

        // GET: Filmovi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmovi.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Filmovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Filmovi.Find(id);
            db.Filmovi.Remove(film);
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
