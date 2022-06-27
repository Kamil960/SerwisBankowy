using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankData.Data.Bank
{
	public class Koszyk
    {
		[Key]
		public int IdKoszyk { get; set; }
		[Required]
		[ForeignKey("Nagrody")]
		public int IdNagroda { get; set; }
		public int Ilosc { get; set; }
		public int LiczbaPunktow { get; set; }
		public string Kategoria { get; set; }
		public string Nazwa { get; set; }
		public string Grafika { get; set; }
		public bool? CzyAktywna { get; set; }
	}
}
