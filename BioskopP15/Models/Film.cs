using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioskopP15.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        [Required(ErrorMessage = "Morate odabrati zanr filma")]
        public int ZanrId { get; set; }

        [Required(ErrorMessage = "Morate uneti naslov Filma")]
        [StringLength(50, ErrorMessage = "Naslov sadrzi maksimalno 50 karaktera")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Morate uneti datum prikazivanja filma")]
        [Display(Name = "Datum prikazivanja")]
        [DisplayFormat(DataFormatString = "{0:MM.dd.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumPrikazivanja { get; set; }
        public Decimal Cena { get; set; }

        public virtual Zanr Zanr { get; set; }




    }
}