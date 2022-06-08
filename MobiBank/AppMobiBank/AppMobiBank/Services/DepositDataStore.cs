using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public class DepositDataStore : ItemDataStore<Deposit>
    {
        #region Constructor
        public DepositDataStore():base()
        {
            items = new List<Deposit>
            {
                new Deposit{IdDeposit = 1, IdOperation = 4, InitialContribution = 1000, Percent = 10, Name = "Prosto liczona"},
                new Deposit{IdDeposit = 2, IdOperation = 5, InitialContribution = 1000, Percent = 10, Name = "Długoterminowa"},
                new Deposit{IdDeposit = 3, IdOperation = 6, InitialContribution = 1000, Percent = 10, Name = "Klepsydra"},
            };
        }
        #endregion
        #region Methods
        public override Deposit Find(Deposit item)
        {
            var card = items.Where((Deposit c) => c.IdDeposit == item.IdDeposit).FirstOrDefault();
            return card;
        }

        public override Deposit Find(int id)
        {
            var card = items.Where((Deposit c) => c.IdDeposit == id).FirstOrDefault();
            return card;
        }
        #endregion

    }
}
