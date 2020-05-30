using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioskopP15.Models
{
    public class Karta
    {
        public int KartaId { get; set; }
        public int FilmId { get; set; }
        public int BrojSedista { get; set; }
        public string KorisnikId { get; set; }
    }
}