using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BioskopP15.Models;
using Microsoft.AspNet.Identity;

namespace BioskopP15.Controllers
{
    public class BiletarnicaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ApplicationDbContext dBase = new ApplicationDbContext();
            List<Film> Film = dBase.Filmovi.ToList();
            dBase.Dispose();
            return View(Film);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Tickets(int id)
        {
            ApplicationDbContext dBase = new ApplicationDbContext();
            Biletarnica bModel = new Biletarnica();
            bModel.Film = dBase.Filmovi.FirstOrDefault(f => f.FilmId == id);
            bModel.ProdateKarte = dBase.ProdateKarte.Where(k => k.FilmId == id).ToList();
            dBase.Dispose();
            return View(bModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Tickets(FormCollection form)
        {
            ApplicationDbContext dBase = new ApplicationDbContext();
            string sedista = form["selkarte"];
            string[] idsedista = sedista.Split(',');
            int FilmId = Convert.ToInt32(form["film"]);
            string korisnikId = User.Identity.GetUserId();
            for (int i = 0; i < idsedista.Count(); i++)
            {
                Karta karta = new Karta();
                karta.BrojSedista = Convert.ToInt32(idsedista[i]);
                karta.FilmId = FilmId;
                karta.KorisnikId = korisnikId;
                dBase.ProdateKarte.Add(karta);
                dBase.SaveChanges();
            }
            return RedirectToAction("Index", "Biletarnica");
        }
    }
}