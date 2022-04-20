using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.CMS
{
    public class Kontakt
    {
        [Key]
        public int IdKontakt { get; set; }

        [Required(ErrorMessage = "Wpisz nazwe")]
        [Display(Name = "Tytuł")]
        public string Tytul { get; set; }
        [Required(ErrorMessage = "Wpisz opis")]
        [Display(Name = "Opis")]
        [MaxLength(32, ErrorMessage = "Może zawierać maksymalnie 32 znaków")]
        public string Opis1 { get; set; }
        [Required(ErrorMessage = "Wpisz opis")]
        [Display(Name = "Opis")]
        [MaxLength(32, ErrorMessage = "Może zawierać maksymalnie 32 znaków")]
        public string Opis2 { get; set; }
        [Required(ErrorMessage = "Wpisz opis")]
        [Display(Name = "Opis")]
        [MaxLength(32, ErrorMessage = "Może zawierać maksymalnie 32 znaków")]
        public string Opis3 { get; set; }
        [Required(ErrorMessage = "Wpisz opis")]
        [Display(Name = "Opis")]
        [MaxLength(32, ErrorMessage = "Może zawierać maksymalnie 32 znaków")]
        public string Opis4 { get; set; }
        [Required(ErrorMessage = "Wpisz adres")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Wpisz numer stacjonarny")]
        [Display(Name = "Numer telefonu")]
        public string NrTelefonuSt { get; set; }
        [Required(ErrorMessage = "Wpisz numer komórkowy")]
        [Display(Name = "Numer telefonu")]
        public string NrTelefonuKom { get; set; }
        [Required(ErrorMessage = "Wpisz email")]
        [Display(Name = "Adres mailowy")]
        public string Email { get; set; }
        public string? Grafika { get; set; }
    }
}
