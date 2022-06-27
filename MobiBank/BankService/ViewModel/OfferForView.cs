using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankService.ViewModel
{
    [DataContract]
    public class OperationForView
    {
        #region Properties
        [DataMember]
        public int IdOperation { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
        [DataMember]
        public DateTime? BeginingDate { get; set; }
        [DataMember]
        public DateTime? FinishingDate { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public decimal? Value { get; set; }

        public OperationForView(Operacje offer)
        {
            IdOperation = offer.IdOperation;
            AccountNumber = offer.AccountNumber;
            IsActive = offer.IsActive;
            BeginingDate = offer.BeginingDate;
            FinishingDate = offer.FinishingDate;
            Type = offer.Type;
            Value = offer.Value;

        }
        #endregion
    }
}