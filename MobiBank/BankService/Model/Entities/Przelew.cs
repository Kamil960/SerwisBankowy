//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankService.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Przelew
    {
        public int IdPrzelew { get; set; }
        public string NrRachunekZewnetrzny { get; set; }
        public Nullable<decimal> Kwota { get; set; }
        public string Rodzaj { get; set; }
        public string Nazwa { get; set; }
        public Nullable<int> IdRachunek { get; set; }
    
        public virtual Rachunek Rachunek { get; set; }
    }
}
