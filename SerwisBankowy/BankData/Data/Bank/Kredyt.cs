using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.Bank
{
	public class Kredyt
	{
        [Key]
        public int IdUslugaSzczegolowa { get; set; }
        [ForeignKey("Usluga")]
        public int IdUsluga { get; set; }

        [Required(ErrorMessage = "Wpisz nazwe")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Wpisz opis")]
        [MaxLength(160, ErrorMessage = "Może zawierać maksymalnie 160 znaków")]
        public string Opis { get; set; }
        public string? Procent { get; set; }
        public string? Grafika { get; set; }
        public int? Pozycja { get; set; }
        public bool? CzyAktywna { get; set; }
        public int LiczbaPunktow { get; set; }
    }
}
