namespace BioskopP15.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BioskopP15.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<BioskopP15.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BioskopP15.Models.ApplicationDbContext context)
        {
            context.Zanrovi.AddOrUpdate(
                z => z.ZanrId,
                          new Zanr { ZanrId = 1, Naziv = "Akcija" },
                          new Zanr { ZanrId = 2, Naziv = "Naucna fantastika" },
                          new Zanr { ZanrId = 3, Naziv = "Komedija" },
                          new Zanr { ZanrId = 4, Naziv = "Animirani film" },
                          new Zanr { ZanrId = 5, Naziv = "Drama" });

            context.Filmovi.AddOrUpdate(
                f => f.FilmId,
                new Film { FilmId = 1, ZanrId = 1, Naslov = "Gringo", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 2, ZanrId = 1, Naslov = "Tomb Raider", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 3, ZanrId = 2, Naslov = "Ready Player One", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 4, ZanrId = 2, Naslov = "Projekat:Titan", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 5, ZanrId = 3, Naslov = "Nocne Igre", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 6, ZanrId = 3, Naslov = "Gringo", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 7, ZanrId = 4, Naslov = "Ferdinand", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 8, ZanrId = 4, Naslov = "Zec Petar", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 9, ZanrId = 5, Naslov = "Led", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 10, ZanrId = 5, Naslov = "Ponocno Sunce", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 11, ZanrId = 3, Naslov = "Nece Moci Ove Noci", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 },
                new Film { FilmId = 12, ZanrId = 5, Naslov = "Poslednja Zelja", DatumPrikazivanja = new DateTime(2019, 10, 31), Cena = 300 });

            context.Roles.AddOrUpdate(
            r => r.Name,
            new IdentityRole { Name = "Admin" },
            new IdentityRole { Name = "Korisnik" }
             );

            var user = new ApplicationUser { UserName = "Admin@gmail.com", Email = "Admin@gmail.com" };

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            um.Create(user, "password");

            um.AddToRole(user.Id, "Admin");


        }
    }
}
