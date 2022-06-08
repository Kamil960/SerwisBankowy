using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankService.ViewModel
{
    [DataContract]
    public class InsurenceForView
    {
        #region Properties
        [DataMember]
        public int IdInsurence { get; set; }

        [DataMember]
        public decimal? Value { get; set; }
        [DataMember]
        public decimal? Price { get; set; }
        [DataMember]
        public string Kind { get; set; }
        #endregion
        #region Constructor
        public InsurenceForView(Ubezpieczenie insurence)
        {
            IdInsurence = insurence.IdUbezpieczenie;
            Value = insurence.WartoscPolisy;
            Price = insurence.Skladka;
            Kind = insurence.RodzajPolisy;
        }
        #endregion
    }
}