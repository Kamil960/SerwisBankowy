using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.Bank
{
    public class Nagrody
    {
        [Key]
        public int IdNagrody { get; set; }
        public int LiczbaPunktow { get; set; }
        public string Nazwa { get; set; }
        public string Kategoria { get; set; }
        public string Grafika { get; set; }
        public bool? CzyAktywna { get; set; }
    }
}
