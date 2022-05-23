using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankService.Services
{
    public class BankEntity
    {
        #region Properties
        protected Mobile_BankEntities _mobileBank;
        #endregion
        #region Constructor
        public BankEntity()
        {
            _mobileBank = new Mobile_BankEntities();
        }
        #endregion

    }
}