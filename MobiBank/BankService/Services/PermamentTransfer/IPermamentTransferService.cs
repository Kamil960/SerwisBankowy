using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.PermamentTransfer
{
    [ServiceContract]
    public interface IPermamentTransferService
    {
        [OperationContract]
        List<PTForView> GetPTForViews();
    }
    [DataContract]
    public class PTForView
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
        public PTForView(ZlecenieStale permamentTransfer)
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
