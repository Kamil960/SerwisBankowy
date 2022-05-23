using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public class OperationDataStore : ItemDataStore<Operation>
    {
        #region Constructor
        public OperationDataStore():base()
        {
            items = new List<Operation>
            {
                 new Operation { IdOperation = 1, AccountNumber = "1234567", Type = "przelew", Value = -120, BeginingDate = DateTime.Now},
                 new Operation { IdOperation = 2, AccountNumber = "8920982", Type = "przelew", Value = 120, BeginingDate = DateTime.Now},
                 new Operation { IdOperation = 3, AccountNumber = "1435903", Type = "przelew", Value = 20, BeginingDate = DateTime.Now},
                 new Operation { IdOperation = 4, AccountNumber = "1435903", Type = "założenie lokaty", BeginingDate = new DateTime(2015, 12, 25), FinishDate = DateTime.Now.AddYears(5), IsActive = true},
                 new Operation { IdOperation = 4, AccountNumber = "1435903", Type = "założenie lokaty", BeginingDate = DateTime.Now, FinishDate = DateTime.Now.AddYears(5), IsActive = true},
                 new Operation { IdOperation = 4, AccountNumber = "1435903", Type = "założenie lokaty", BeginingDate = new DateTime(2020, 05, 22), FinishDate = DateTime.Now.AddYears(5), IsActive = true},
            };
        }
        #endregion
        #region Methods
        public override Operation Find(Operation item)
        {
            var Offer = items.Where((Operation c) => c.IdOperation == item.IdOperation).FirstOrDefault();
            return Offer;
        }

        public override Operation Find(int id)
        {
            var Offer = items.Where((Operation c) => c.IdOperation == id).FirstOrDefault();
            return Offer;
        }
        #endregion
    }
}
