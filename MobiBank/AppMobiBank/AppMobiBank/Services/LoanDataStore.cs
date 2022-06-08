using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public class LoanDataStore : ItemDataStore<Loan>
    {
        #region Constructor
        public LoanDataStore():base()
        {
            items = new List<Loan>
            {
                new Loan { IdLoan = 1, IdOperation = 11, Name = "Hipoteczny", LastPay = DateTime.Now.AddYears(5), NextPay = DateTime.Now.AddDays(25), Percent = "10%", Sum = 500000 },
                new Loan { IdLoan = 2, IdOperation = 12, Name = "Szybki", LastPay = DateTime.Now.AddYears(5), NextPay = DateTime.Now.AddDays(25), Percent = "10%", Sum = 500000 },
                new Loan { IdLoan = 3, IdOperation = 13, Name = "Leasing samochodu", LastPay = DateTime.Now.AddYears(5), NextPay = DateTime.Now.AddDays(25), Percent = "10%", Sum = 500000 },
            };
        }
        #endregion
        #region Methods
        public override Loan Find(Loan item)
        {
            var Loan = items.Where((Loan c) => c.IdLoan == item.IdLoan).FirstOrDefault();
            return Loan;
        }

        public override Loan Find(int id)
        {
            var Loan = items.Where((Loan c) => c.IdLoan == id).FirstOrDefault();
            return Loan;
        }
        #endregion
    }
}
