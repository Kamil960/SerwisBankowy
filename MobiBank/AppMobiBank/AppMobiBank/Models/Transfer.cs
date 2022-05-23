using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models
{
    public class Transfer
    {
        public int IdTransfer { get; set; }
        public int IdOperation { get; set; }
        public string ForeignNumber { get; set; }
        public string Title { get; set; }
    }
}
