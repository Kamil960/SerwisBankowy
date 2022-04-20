using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.CMS
{
    public class Art3
    {
        [Key]
        public int IdArt3 { get; set; }

        [Required(ErrorMessage = "Wpisz nazwe")]
        [Display(Name = "Tytuł")]
        [MaxLength(50, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Tytul { get; set; }
        [Required(ErrorMessage = "Wpisz treść")]
        [MaxLength(250, ErrorMessage = "Może zawierać maksymalnie 250 znaków")]
        public string Tresc1 { get; set; }
        [Required(ErrorMessage = "Wpisz treść")]
        [MaxLength(250, ErrorMessage = "Może zawierać maksymalnie 250 znaków")]
        public string Tresc2 { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(50, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        [Display(Name = "Pozycja Giełdowa")]
        public string PozGieldowa1 { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(50, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        [Display(Name = "Pozycja Giełdowa")]
        public string PozGieldowa2 { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(32, ErrorMessage = "Może zawierać maksymalnie 32 znaków")]
        [Display(Name = "Pozycja Giełdowa")]
        public string PozGieldowa3 { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(32, ErrorMessage = "Może zawierać maksymalnie 32 znaków")]
        [Display(Name = "Pozycja Giełdowa")]
        public string PozGieldowa4 { get; set; }

        [Required(ErrorMessage = "Wpisz odnośnik do grafiki")]
        public string Grafika { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł")]
        [MaxLength(50, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        [Display(Name = "Tytuł sekcji kryptowalut")]
        public string CrypTytul { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Crypto1 { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Crypto2 { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Crypto3 { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Crypto4 { get; set; }

        [Required(ErrorMessage = "Wpisz odnośnik do grafiki")]
        public string CrypIcon1 { get; set; }
        [Required(ErrorMessage = "Wpisz odnośnik do grafiki")]
        public string CrypIcon2 { get; set; }
        [Required(ErrorMessage = "Wpisz odnośnik do grafiki")]
        public string CrypIcon3 { get; set; }
        [Required(ErrorMessage = "Wpisz odnośnik do grafiki")]
        public string CrypIcon4 { get; set; }

    }
}
