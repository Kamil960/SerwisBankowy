﻿using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.Loan
{
    [ServiceContract]
    public interface ILoanService
    {
        [OperationContract]
        List<LoanForView> GetLoanForView();
    }
    [DataContract]
    public class LoanForView
    {
        #region Properties
        [DataMember]
        public int IdLoan { get; set; }

        [DataMember]
        public decimal? Sum { get; set; }
        [DataMember]
        public string Percent { get; set; }
        #endregion
        #region Constructor
        public LoanForView(Kredyt loan)
        {
            IdLoan = loan.IdKredyt;
            Sum = loan.KwotaKredytu;
            Percent = loan.Oprocentowanie;
        }
        #endregion

    }
}
