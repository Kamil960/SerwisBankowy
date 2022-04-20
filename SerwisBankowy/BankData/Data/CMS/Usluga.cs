using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.CMS
{
    public class Usluga
    {
        [Key]
        public int IdUsluga { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Wpisz pozycje")]
        public int Pozycja { get; set; }

        [Required(ErrorMessage = "Wpisz pozycje")]
        public string Grafika { get; set; }
    }
}
