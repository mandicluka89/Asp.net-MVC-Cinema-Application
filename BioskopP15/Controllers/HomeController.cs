using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BioskopP15.Models;
using System.Data.Entity;

namespace BioskopP15.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.zanrovi = db.Zanrovi.ToList();
            var filmovi = db.Filmovi.Include(f => f.Zanr);
            return View(filmovi.ToList());
        }

        public ActionResult TraziFilmove(string deoNaslova, int ZanrId = 0)
        {
            ViewBag.ZanrId = ZanrId;
            ViewBag.zanrovi = db.Zanrovi.ToList();
            ViewBag.naslov = deoNaslova;

            IQueryable<Film> filmovi = db.Filmovi.Select(f => f);

            if (ZanrId > 0)
            {
                filmovi = filmovi.Where(f => f.ZanrId == ZanrId);
            }
            if (!string.IsNullOrWhiteSpace(deoNaslova))
            {
                filmovi = filmovi.Where(f => f.Naslov.Contains(deoNaslova));
            }
            return View("Index", filmovi);
        }

        public ActionResult Pretraga(string deoNaslova, int ZanrId = 0)
        {
            ViewBag.ZanrId = new SelectList(db.Zanrovi, "ZanrId", "Naziv");

            ViewBag.pretraga = deoNaslova;

            IQueryable<Film> filmovi = db.Filmovi.Select(f => f);
            if (ZanrId > 0)
            {
                filmovi = filmovi.Where(f => f.ZanrId == ZanrId);
            }
            if (!string.IsNullOrWhiteSpace(deoNaslova))
            {
                filmovi = filmovi.Where(f => f.Naslov.Contains(deoNaslova));
            }
            return View(filmovi.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Pocetna()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}