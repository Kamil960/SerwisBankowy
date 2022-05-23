using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.Deposit
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DepositService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DepositService.svc or DepositService.svc.cs at the Solution Explorer and start debugging.
    public class DepositService : BankEntity, IDepositService
    {
        private List<Lokata> _deposit;
        public DepositService() : base()
        {
            _deposit = (from deposit in _mobileBank.Lokata select deposit).ToList();
        }
        List<DepositForView> IDepositService.GetDeposit()
        {
            return _deposit.Select(deposit => new DepositForView(deposit)).ToList();
        }
    }
}
