﻿using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankService.ViewModel
{
    [DataContract]
    public class AccountForView
    {
        #region Properties
        [DataMember]
        public int IdAccount { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public decimal? AccountBalance { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
        [DataMember]
        public int? IdOffer { get; set; }
        #endregion
        #region Constructor
        public AccountForView(Rachunek account)
        {
            IdAccount = account.IdRachunek;
            AccountNumber = account.NrRachunek;
            AccountBalance = account.StanRachunku;
            IsActive = account.CzyAktywny;
        }
        #endregion
    }
}