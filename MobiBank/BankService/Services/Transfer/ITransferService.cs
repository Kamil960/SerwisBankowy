using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services
{
    [ServiceContract]
    public interface ITransferService
    {
        [OperationContract]
        List<TransferForView> GetTransferForView();
    }
    [DataContract]
    public class TransferForView
    {
        #region Properties
        [DataMember]
        public int IdTransfer { get; set; }
        public string ForeignNumber { get; set; }
        [DataMember]
        public decimal? Sum { get; set; }
        [DataMember]
        public string Kind { get; set; }
        [DataMember]
        public string Name { get; set; }
        #endregion
        #region Constructor
        public TransferForView(Przelew transfer)
        {
            IdTransfer = transfer.IdPrzelew;
            ForeignNumber = transfer.NrRachunekZewnetrzny;
            Sum = transfer.Kwota;
            Kind = transfer.Rodzaj;
        }
        #endregion

    }
}
