using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services
{
    public class TransferService : BankEntity, ITransferService
    {
        private List<Przelew> _transfer;
        #region Constructor
        public TransferService() : base()
        {
            _transfer = (from transfer in _mobileBank.Przelew select transfer).ToList();
        }
        #endregion
        public List<TransferForView> GetTransferForView()
        {
            return _transfer.Select(_transfer => new TransferForView(_transfer)).ToList();
        }
    }
}
