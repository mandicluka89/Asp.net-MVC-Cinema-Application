using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioskopP15.Models
{
    [Table("Zanr")]
    public class Zanr
    {
        public Zanr()
        {
            Filmovi = new HashSet<Film>();
        }

        public int ZanrId { get; set; }
        [Required(ErrorMessage = "Unesite naziv zanra")]
        [StringLength(50, ErrorMessage = "Zanr sadrzi maksimalno 50 karaktera")]

        public string Naziv { get; set; }

        public virtual ICollection<Film> Filmovi { get; set; }
    }
}