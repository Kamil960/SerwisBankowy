using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.CMS
{
    public class Art2
    {
        [Key]
        public int IdArt2 { get; set; }

        [Required(ErrorMessage = "Wpisz nazwe")]
        [Display(Name = "Tytuł")]
        [MaxLength(32, ErrorMessage = "Może zawierać maksymalnie 50 znaków")]
        public string Tytul { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(350, ErrorMessage = "Może zawierać maksymalnie 350 znaków")]
        public string Tresc1 { get; set; }
        [Required(ErrorMessage = "Wpisz treść")]
        [MaxLength(350, ErrorMessage = "Może zawierać maksymalnie 350 znaków")]
        public string Tresc2 { get; set; }
        [Required(ErrorMessage = "Wpisz adres grafiki")]
        public string Grafika { get; set; }

    }
}
