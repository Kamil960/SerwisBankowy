using BankService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankService" in both code and config file together.
    [ServiceContract]
    public interface IBankService
    {

        [OperationContract]
        List<TransferForView> GetTransferForView();

        [OperationContract]
        List<PermamentTransferForView> GetPTForViews();

        [OperationContract]
        List<OperationForView> GetOperationForViews();

        [OperationContract]
        List<OperationForView> GetOperationByDate();

        [OperationContract]
        List<LoanForView> GetLoanForView();

        [OperationContract]
        List<InsurenceForView> GetInsurance();

        [OperationContract]
        List<DepositForView> GetDeposit();

        [OperationContract]
        List<CardForView> GetCard();

        [OperationContract]
        List<AccountForView> GetAccount();
    }
}
