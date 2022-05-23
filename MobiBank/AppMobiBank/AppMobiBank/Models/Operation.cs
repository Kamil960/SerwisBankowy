using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models
{
    public class Operation
    {
        public int IdOperation { get; set; }
        public string AccountNumber { get; set; }
        public bool? IsActive { get; set; }
        public string Type { get; set; }
        public decimal? Value { get; set; }
        public DateTime BeginingDate { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
