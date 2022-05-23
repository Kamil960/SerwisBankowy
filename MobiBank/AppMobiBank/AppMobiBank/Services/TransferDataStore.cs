using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public class TransferDataStore : ItemDataStore<Transfer>
    {
        #region Constructor
        public TransferDataStore():base()
        {
            items = new List<Transfer>
            {
                new Transfer { IdTransfer = 1, ForeignNumber = "8934521", IdOperation = 1, Title = "wymowny"},
            };
        }
        #endregion
        #region Methods
        public override Transfer Find(Transfer item)
        {
            var Transfer = items.Where((Transfer c) => c.IdTransfer == item.IdTransfer).FirstOrDefault();
            return Transfer;
        }

        public override Transfer Find(int id)
        {
            var Transfer = items.Where((Transfer c) => c.IdTransfer == id).FirstOrDefault();
            return Transfer;
        }
        #endregion
    }
}
