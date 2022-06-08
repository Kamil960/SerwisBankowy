using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public class InsurenceDataStore : ItemDataStore<Insurence>
    {
        #region Constructor
        public InsurenceDataStore():base()
        {
            items = new List<Insurence>
            {
                new Insurence{IdInsurence = 1, IdOperation = 8, Kind = "Zdrowotne", Price = 180, Value = 120000},
                new Insurence{IdInsurence = 2, IdOperation = 9, Kind = "AC", Price = 120, Value = 120000},
                new Insurence{IdInsurence = 3, IdOperation = 10, Kind = "Od pożaru", Price = 60, Value = 120000},
            };
        }
        #endregion
        #region Methods
        public override Insurence Find(Insurence item)
        {
            var Insurence = items.Where((Insurence c) => c.IdInsurence == item.IdInsurence).FirstOrDefault();
            return Insurence;
        }

        public override Insurence Find(int id)
        {
            var Insurence = items.Where((Insurence c) => c.IdInsurence == id).FirstOrDefault();
            return Insurence;
        }
        #endregion
    }
}
