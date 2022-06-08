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
        public OperationDataStore() : base()
        {
            items = new List<Operation>
            {
                new Operation { IdOperation = 1, AccountNumber = "1234567", Type = "przelew", Value = -120, BeginingDate = DateTime.Now },
                new Operation { IdOperation = 2, AccountNumber = "8920982", Type = "przelew", Value = 120, BeginingDate = DateTime.Now },
                new Operation { IdOperation = 3, AccountNumber = "1435903", Type = "przelew", Value = 20, BeginingDate = DateTime.Now },
                new Operation { IdOperation = 4, AccountNumber = "8920982", Type = "założenie lokaty", Value = -1000, BeginingDate = new DateTime(2021, 6, 4), FinishDate = DateTime.Now.AddYears(1), IsActive = true },
                new Operation { IdOperation = 5, AccountNumber = "1234567", Type = "założenie lokaty", Value = -1000, BeginingDate = DateTime.Now, FinishDate = DateTime.Now.AddYears(5), IsActive = true },
                new Operation { IdOperation = 6, AccountNumber = "1435903", Type = "założenie lokaty", Value = -1000, BeginingDate = new DateTime(2020, 05, 22), FinishDate = DateTime.Now.AddYears(5), IsActive = true },
                new Operation { IdOperation = 8, AccountNumber = "8920982", Type = "otwarcie polisy", BeginingDate = new DateTime(2021, 05, 22), FinishDate = DateTime.Now.AddYears(1), IsActive = true },
                new Operation { IdOperation = 9, AccountNumber = "1234567", Type = "otwarcie polisy", BeginingDate = new DateTime(2021, 05, 22), FinishDate = DateTime.Now.AddYears(1), IsActive = true },
                new Operation { IdOperation = 10, AccountNumber = "1435903", Type = "otwarcie polisy", BeginingDate = new DateTime(2021, 05, 22), FinishDate = DateTime.Now.AddYears(1), IsActive = true },
                new Operation { IdOperation = 11, AccountNumber = "8920982", Type = "otrzymanie kredytu", BeginingDate = new DateTime(2020, 05, 22), FinishDate = DateTime.Now.AddYears(20), IsActive = true },
                new Operation { IdOperation = 12, AccountNumber = "1234567", Type = "otrzymanie kredytu", BeginingDate = DateTime.Now, FinishDate = DateTime.Now.AddYears(5), IsActive = true },
                new Operation { IdOperation = 13, AccountNumber = "1435903", Type = "otrzymanie kredytu", BeginingDate = new DateTime(2015, 05, 22), FinishDate = DateTime.Now.AddYears(15), IsActive = true },

            };
        }
        #endregion
        #region Methods
        public override Operation Find(Operation item)
        {
            var Op = items.Where((Operation c) => c.IdOperation == item.IdOperation).FirstOrDefault();
            return Op;
        }

        public override Operation Find(int id)
        {
            var Op = items.Where((Operation c) => c.IdOperation == id).FirstOrDefault();
            return Op;
        }
        public List<Operation> FindDate(DateTime date)
        {
            var Op = items.Where((Operation c) => c.FinishDate == date).ToList();
            return Op;
        }
        public async Task<List<Operation>> FindType(string type)
        {
            var Op = items.Where((Operation c) => c.Type == type).ToList();
            return await Task.FromResult(Op);
        }
        #endregion
    }
}
