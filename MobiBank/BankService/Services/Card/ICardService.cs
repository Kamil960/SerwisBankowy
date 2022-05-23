using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.Card
{
    [ServiceContract]
    public interface ICardService
    {
        [OperationContract]
        List<CardForView> GetCard();
    }
    [DataContract]
    public class CardForView
    {
        #region Properties
        [DataMember]
        public int IdCard { get; set; }

        [DataMember]
        public string CardNumber { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string UrlGrafic { get; set; }
        public string Kind { get; set; }
        #endregion
        #region Constructor
        public CardForView(Karta card)
        {
            IdCard = card.IdKarty;
            CardNumber = card.NrKarty;
            Color = card.Kolor;
            UrlGrafic = card.UrlGrafika;
           // Kind = card.Rodzaj;
        }
        #endregion

    }
}
