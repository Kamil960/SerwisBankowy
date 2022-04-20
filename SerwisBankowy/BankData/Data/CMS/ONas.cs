using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.CMS
{
    public class ONas
    {
        [Key]
        public int IdONas { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł")]
        [Display(Name ="Tytuł")]
        public string Tytul { get; set; }
        [Required(ErrorMessage = "Wpisz opis")]
        public string Opis { get; set; }
        public string? Grafika { get; set; }
    }
}
