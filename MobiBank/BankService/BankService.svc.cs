using BankService.Model.Entities;
using BankService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BankService.svc or BankService.svc.cs at the Solution Explorer and start debugging.
    public class BankService : IBankService
    {
        Mobile_BankEntities _mobileBank;

        #region Constructor
        public BankService()
        {
            _mobileBank = new Mobile_BankEntities();
        }
        #endregion
        public List<AccountForView> GetAccount()
        {
            List<Rachunek> _account = (from account in _mobileBank.Rachunek select account).ToList();
            return _account.Select(account => new AccountForView(account)).ToList();
        }

        public List<CardForView> GetCard()
        {
            List<Karta> _card = (from card in _mobileBank.Karta select card).ToList();
            return _card.Select(card => new CardForView(card)).ToList();
        }

        public List<DepositForView> GetDeposit()
        {
            List<Lokata> _deposit = (from deposit in _mobileBank.Lokata select deposit).ToList();
            return _deposit.Select(deposit => new DepositForView(deposit)).ToList();
        }

        public List<InsurenceForView> GetInsurance()
        {
            List<Ubezpieczenie> _insurance = (from insurance in _mobileBank.Ubezpieczenie select insurance).ToList();
            return _insurance.Select(insurance => new InsurenceForView(insurance)).ToList();
        }

        public List<LoanForView> GetLoanForView()
        {
            List<Kredyt> _loan = (from loan in _mobileBank.Kredyt select loan).ToList();
            return _loan.Select(loan => new LoanForView(loan)).ToList();
        }

        public List<OfferForView> GetOfferByDate()
        {
            return GetOfferForViews().OrderByDescending(offer => offer.FinishDate).ToList();
        }
        public List<OfferForView> GetOfferForViews()
        {
            List<UslugaSzczegolowa> _offer = (from offer in _mobileBank.UslugaSzczegolowa select offer).ToList();
            return _offer.Select(offer => new OfferForView(offer)).ToList();
        }

        public List<PermamentTransferForView> GetPTForViews()
        {
            List<ZlecenieStale> _permamentTransfer = (from pt in _mobileBank.ZlecenieStale select pt).ToList();
            return _permamentTransfer.Select(pt => new PermamentTransferForView(pt)).ToList();
        }

        public List<TransferForView> GetTransferForView()
        {
            List<Przelew> _transfer = (from transfer in _mobileBank.Przelew select transfer).ToList();
            return _transfer.Select(transfer => new TransferForView(transfer)).ToList();
        }
    }
}

