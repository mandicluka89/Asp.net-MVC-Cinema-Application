using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioskopP15.Models
{
    public class Biletarnica
    {
        public Film Film { get; set; }
        public List<Karta> ProdateKarte { get; set; }
    }
}