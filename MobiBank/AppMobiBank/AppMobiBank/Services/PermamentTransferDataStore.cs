using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public class PermamentTransferDataStore : ItemDataStore<PermamentTransfer>
    {
        #region Constructor
        public PermamentTransferDataStore():base()
        {
            items = new List<PermamentTransfer>
            {
                new PermamentTransfer { IdPT = 1, IdTransfer = 1, Frecuency = 7, Term = DateTime.Now},
            };
        }
        #endregion
        #region Methods
        public override PermamentTransfer Find(PermamentTransfer item)
        {
            var PermamentTransfer = items.Where((PermamentTransfer c) => c.IdPT == item.IdPT).FirstOrDefault();
            return PermamentTransfer;
        }

        public override PermamentTransfer Find(int id)
        {
            var PermamentTransfer = items.Where((PermamentTransfer c) => c.IdPT == id).FirstOrDefault();
            return PermamentTransfer;
        }
        #endregion
    }
}
