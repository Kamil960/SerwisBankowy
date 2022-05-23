using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobiBank.Services
{
    public class CardDataStore : ItemDataStore<Card>
    {
        #region Constructor
        public CardDataStore():base()
        {
            items = new List<Card>()
            {
                new Card{IdCard = 1, CardNumber = "12345", Color = "czarny", Kind = "debetowa", IsActive = true, Activity = "Aktywna" },
                new Card{IdCard = 2, CardNumber = "67890", Color = "złoty", Kind = "płatnicza", IsActive = true, Activity = "Aktywna" },
                new Card{IdCard = 3, CardNumber = "16273", Color = "srebrny", Kind = "debetowa", IsActive = true, Activity = "Aktywna" },
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
