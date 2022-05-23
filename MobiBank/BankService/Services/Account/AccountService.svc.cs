using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BankService.Services
{
    public class AccountService : BankEntity, IAccountService
    {
        private List<Rachunek> _account;
        public AccountService():base()
        {
            _account = (from account in _mobileBank.Rachunek select account).ToList();
        }
        public List<AccountForView> GetAccount()
        {
            return _account.Select(account => new AccountForView(account)).ToList();
        }
    }
}
