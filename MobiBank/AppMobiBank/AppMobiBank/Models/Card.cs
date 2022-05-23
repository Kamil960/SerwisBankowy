using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models
{
    public class Card
    {
        public int IdCard { get; set; }
        public string CardNumber { get; set; }
        public string Kind { get; set; }
        public string Color { get; set; }
        public string UrlGrafic { get; set; }
        public bool IsActive { get; set; }  
        public string Activity { get; set; }    
    }
}
