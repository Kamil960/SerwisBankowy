using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.Deposit
{
    [ServiceContract]
    public interface IDepositService
    {
        [OperationContract]
        List<DepositForView> GetDeposit();
    }
    [DataContract]
    public class DepositForView
    {
        #region Properties
        [DataMember]
        public int IdDeposit { get; set; }

        [DataMember]
        public string Percent{ get; set; }
        [DataMember]
        public decimal? InitialContribution { get; set; }
        #endregion
        #region Constructor
        public DepositForView(Lokata deposit)
        {
            IdDeposit = deposit.IdLokata;
            Percent = deposit.Oprocentowanie;
            InitialContribution = deposit.WkladPoczatkowy;
        }
        #endregion

    }
}
