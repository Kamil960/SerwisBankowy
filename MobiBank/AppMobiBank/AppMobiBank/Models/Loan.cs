using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models
{
    public class Loan
    {
        public int IdLoan { get; set; }
        public int IdOperation { get; set; }
        public decimal? Sum { get; set; }
        public string Percent { get; set; }
        public DateTime NextPay { get; set; }
        public DateTime LastPay { get; set; }
        public string Name { get; set; }
    }
}
