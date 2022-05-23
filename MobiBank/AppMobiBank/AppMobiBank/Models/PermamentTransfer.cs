using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models
{
    public class PermamentTransfer
    {
        public int IdPT { get; set; }
        public int IdTransfer { get; set; }
        public int Frecuency { get; set; }
        public DateTime Term { get; set; }
    }
}
