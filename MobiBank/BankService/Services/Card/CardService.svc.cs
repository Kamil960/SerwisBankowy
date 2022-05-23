using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.Card
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CardService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CardService.svc or CardService.svc.cs at the Solution Explorer and start debugging.
    public class CardService : BankEntity, ICardService
    {
        private List<Karta> _card;
        public CardService() : base()
        {
            _card = (from card in _mobileBank.Karta select card).ToList();
        }

        public List<CardForView> GetCard()
        {
            return _card.Select(card => new CardForView(card)).ToList();
        }
    }
}
