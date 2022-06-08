using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankService.ViewModel
{
    [DataContract]
    public class PermamentTransferForView
    {
        #region Properties
        [DataMember]
        public int IdPT { get; set; }
        [DataMember]
        public string ForeignNumber { get; set; }
        [DataMember]
        public decimal? Sum { get; set; }
        [DataMember]
        public string Kind { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Term { get; set; }
        #endregion
        #region Constructor
        public PermamentTransferForView(ZlecenieStale permamentTransfer)
        {
            IdPT = permamentTransfer.IdZlecenieStale;
            ForeignNumber = permamentTransfer.NrRachunekZewnetrzny;
            Sum = permamentTransfer.Kwota;
            Kind = permamentTransfer.Rodzaj;
            Term = permamentTransfer.Okres;
        }
        #endregion
    }
}