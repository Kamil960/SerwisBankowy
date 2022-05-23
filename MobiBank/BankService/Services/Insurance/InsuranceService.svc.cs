using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.Insurance
{
    public class InsuranceService : BankEntity, IInsuranceService
    {
        private List<Ubezpieczenie> _insurance;
        public InsuranceService() : base()
        {
            _insurance = (from insurance in _mobileBank.Ubezpieczenie select insurance).ToList();
        }
        List<InsurenceForView> IInsuranceService.GetInsurance()
        {
            return _insurance.Select(insurance => new InsurenceForView(insurance)).ToList();
        }
    }
}
