using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models
{
    public class Insurence
    {
        public int IdInsurence { get; set; }
        public decimal? Value { get; set; }
        public decimal? Price { get; set; }
        public string Kind { get; set; }
    }
}
