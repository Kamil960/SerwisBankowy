using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models
{
    public class Deposit
    {
        public int IdDeposit { get; set; }
        public int IdOperation { get; set; }
        public decimal Percent { get; set; }
        public decimal InitialContribution { get; set; }
        public string Name { get; set; }
    }
}
