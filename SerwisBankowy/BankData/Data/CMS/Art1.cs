using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.CMS
{
    public class Art1
    {
        [Key]
        public int IdArt1 { get; set; }

        [Required(ErrorMessage = "Wpisz nazwe")]
        [Display(Name = "Tytuł")]
        [MaxLength(50, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Tytul { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(70, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Nazwa1 { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(70, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Nazwa2 { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(70, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Nazwa3 { get; set; }
        [Required(ErrorMessage = "Wpisz odnośnik do grafiki")]
        public string Grafika1 { get; set; }
        [Required(ErrorMessage = "Wpisz odnośnik do grafiki")]
        public string Grafika2 { get; set; }
        [Required(ErrorMessage = "Wpisz odnośnik do grafiki")]
        public string Grafika3 { get; set; }

        [Required(ErrorMessage = "Wpisz opis")]
        [MaxLength(250, ErrorMessage = "Może zawierać maksymalnie 250 znaków")]
        public string Opis1 { get; set; }
        [Required(ErrorMessage = "Wpisz opis")]
        [MaxLength(250, ErrorMessage = "Może zawierać maksymalnie 250 znaków")]
        public string Opis2 { get; set; }
        [Required(ErrorMessage = "Wpisz opis")]
        [MaxLength(250, ErrorMessage = "Może zawierać maksymalnie 250 znaków")]
        public string Opis3 { get; set; }
        [Required(ErrorMessage = "Wpisz podsumowanie")]
        [MaxLength(300, ErrorMessage = "Może zawierać maksymalnie 300 znaków")]
        public string Podsumowanie { get; set; }
    }
}
