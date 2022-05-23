using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.PermamentTransfer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PermamentTransferService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PermamentTransferService.svc or PermamentTransferService.svc.cs at the Solution Explorer and start debugging.
    public class PermamentTransferService : BankEntity, IPermamentTransferService
    {
        private List<ZlecenieStale> _permamentTransfer;

        public PermamentTransferService() : base()
        {
            _permamentTransfer = (from pt in _mobileBank.ZlecenieStale select pt).ToList();

        }

        public List<PTForView> GetPTForViews()
        {
            return _permamentTransfer.Select(pt => new PTForView(pt)).ToList();
        }
    }
}
