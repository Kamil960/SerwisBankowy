using AppMobiBank.Models;
using System.Linq;
using Xamarin.Forms;
using BankServiceReference;
using System.Collections.Generic;
using System;

namespace AppMobiBank.Services
{
    public class CardDataStore : ItemDataStore<Card>
    {

         #region Constructor
        public CardDataStore():base()
        {
            //try
            //{
            //    List<CardForView> CardFV = BankServices.GetCard(new GetCardRequest()).GetCardResult.ToList();
            //    items = new List<Card>();
            //    foreach (var k in CardFV)
            //        items.Add(new Card(k));
            //}
            //catch(Exception e)
            //{
            //    items = new List<Card>()
            //    {
            //        new Card{IdCard = 1, AccountNumber = "1234567", CardNumber = "12345", Color = "czarny", Kind = "debetowa", IsActive = true, Activity = "Aktywna" },
            //        new Card{IdCard = 2, AccountNumber = "8920982", CardNumber = "67890", Color = "złoty", Kind = "kredytowa", IsActive = true, Activity = "Aktywna" },
            //        new Card{IdCard = 3, AccountNumber = "1234567", CardNumber = "16273", Color = "srebrny", Kind = "debetowa", IsActive = true, Activity = "Aktywna" },
            //    };
            //}

            //items = bankEntities.Karta.Select(k => 
            //new Card 
            //{ 
            //    IdCard = k.IdKarty,
            //    AccountNumber = k.NumerKonta,
            //    CardNumber = k.NrKarty,
            //    Color = k.Kolor,
            //    Kind = k.Rodzaj,
            //    IsActive = k.CzyAktywna,
            //    Activity = k.Aktywność
            //} ).ToList();
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
