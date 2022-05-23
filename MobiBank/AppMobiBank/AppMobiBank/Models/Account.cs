using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models
{
    public class Account
    {
        public int IdAccount { get; set; }
        public string AccountNumber { get; set; }
        public decimal? AccountBalance { get; set; }
        public bool? IsActive { get; set; }
    }
}
