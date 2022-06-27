using BankServiceReference;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMobiBank.Models
{
    public class Card
    {
        public Card() { }
        public Card(CardForView card)
        {
            IdCard = card.IdCard;
            CardNumber = card.CardNumber;
            AccountNumber = card.AccountNumber;
            Color = card.Color;
            Kind = card.Kind;
            IsActive = card.IsActive;
            Activity = card.Activity;
        }
        public int IdCard { get; set; }
        public string AccountNumber { get; set; }
        public string CardNumber { get; set; }
        public string Kind { get; set; }
        public string Color { get; set; }
        public string UrlGrafic { get; set; }
        public bool? IsActive { get; set; }  
        public string Activity { get; set; }    
    }
}
