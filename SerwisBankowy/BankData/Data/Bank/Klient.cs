using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.Bank
{
    public class Klient
    {
        [Key]
        public int IdKlient { get; set; }

        [Required(ErrorMessage = "Wpisz login")]
        [MaxLength(32, ErrorMessage = "Może zawierać maksymalnie 32 znakii")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Wpisz hasło")]
        [Display(Name = "Hasło")]
        public string Haslo { get; set; }

        [Required(ErrorMessage = "Wpisz imie")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wpisz nazwisko")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Wpisz date urodzenia")]
        [Display(Name = "Data urodzenia")]
        [NotMapped]
        public DateOnly DataUrodzenia { get; set; }

        [Required(ErrorMessage = "Wpisz miejscowość")]
        [Display(Name = "Miejscowość")]
        public string Miejscowosc { get; set; }

        [Required(ErrorMessage = "Wpisz ulice")]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Wpisz numer budynku")]
        [Display(Name = "Numer budynku/lokalu")]
        public string NrBudynku { get; set; }

        [Required(ErrorMessage = "Wpisz kod pocztowy")]
        [Display(Name = "Kod pocztowy")]
        [MaxLength(6, ErrorMessage = "Musi zawierać 6 znaków")]
        [MinLength(6, ErrorMessage = "Musi zawierać 6 znaków")]
        public string KodPocztowy { get; set; }

        [Required(ErrorMessage = "Wpisz miejscowość w której znajduje się poczta")]
        public string Poczta { get; set; }

        [Required(ErrorMessage = "Wpisz numer dokumentu tożsamości")]
        [Display(Name = "Numer dokumentu")]
        [MaxLength(9, ErrorMessage = "Musi zawierać 9 znaków")]
        [MinLength(9, ErrorMessage = "Musi zawierać 9 znaków")]
        public string NrDokumentu { get; set; }
        public int LiczbaPunktow { get; set; }
        public bool? CzyAktywny { get; set; }
    }
}
