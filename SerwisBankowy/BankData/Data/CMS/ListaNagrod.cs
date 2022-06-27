﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Data.CMS
{
    public class ListaNagrod
    {
        [Key]
        public int IdElementu { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe")]
        public string Nazwa { get; set; }
        public int? Pozycja { get; set; }
    }
}
