using AppMobiBank.Models;
using BankServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobiBank.Services
{
    public class CardDataStore : ItemDataStore<Card>
    {

        #region Constructor
        public CardDataStore():base()
        {

            //var _BankServices = DependencyService.Get<BankServiceReference.IBankService>();
            //items = _BankServices.GetCard(null).GetCardResult.Select(k => new Card
            //{
            //    IdCard = k.IdCard,
            //    CardNumber = k.CardNumber,
            //    Kind = k.Kind,
            //    Color = k.Color
            //}).ToList();

            items = new List<Card>()
            {
                new Card{IdCard = 1, AccountNumber = "1234567", CardNumber = "12345", Color = "czarny", Kind = "debetowa", IsActive = true, Activity = "Aktywna" },
                new Card{IdCard = 2, AccountNumber = "8920982", CardNumber = "67890", Color = "złoty", Kind = "kredytowa", IsActive = true, Activity = "Aktywna" },
                new Card{IdCard = 3, AccountNumber = "1234567", CardNumber = "16273", Color = "srebrny", Kind = "debetowa", IsActive = true, Activity = "Aktywna" },
            };

        }
        #endregion
        #region Methods
        public override Card Find(Card item)
        {
            var card = items.Where((Card c) => c.IdCard == item.IdCard).FirstOrDefault();
            return card;
        }

        public override Card Find(int id)
        {
            var card = items.Where((Card c) => c.IdCard == id).FirstOrDefault();
            return card;
        }

        #endregion
    }
}
