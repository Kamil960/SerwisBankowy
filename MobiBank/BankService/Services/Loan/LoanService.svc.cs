using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.Loan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoanService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoanService.svc or LoanService.svc.cs at the Solution Explorer and start debugging.
    public class LoanService : BankEntity, ILoanService
    {
        private List<Kredyt> _loan;

        public LoanService() : base()
        {
            _loan = (from loan in _mobileBank.Kredyt select loan).ToList();

        }

        public List<LoanForView> GetLoanForView()
        {
            return _loan.Select(loan => new LoanForView(loan)).ToList();
        }
    }
}
