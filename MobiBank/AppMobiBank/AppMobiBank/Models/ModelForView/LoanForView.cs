using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models.ModelForView
{
    public class LoanForView
    {
        public decimal? Sum { get; set; }
        public string Percent { get; set; }
        public DateTime NextDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
