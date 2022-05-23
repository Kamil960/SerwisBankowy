using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public class AccountDataStore : ItemDataStore<Account>
    {
        #region Properties

        #endregion
        #region Constructor
        public AccountDataStore():base()
        {
            items = new List<Account>()
            { 
                new Account { IdAccount = 1, AccountNumber = "1234567", AccountBalance = 1000, IsActive = true },
                new Account { IdAccount = 2, AccountNumber = "8920982", AccountBalance = 19000, IsActive = true },
                new Account { IdAccount = 3, AccountNumber = "1435903", AccountBalance = 100, IsActive = true },
            };
        }
        #endregion
        #region Methods
        public override Account Find(Account item)
        {
            var account = items.Where((Account acc) => acc.IdAccount == item.IdAccount).FirstOrDefault();
            return account;
        }

        public override Account Find(int id)
        {
            var account = items.Where((Account acc) => acc.IdAccount == id).FirstOrDefault();
            return account;
        }
        #endregion
    }
}
