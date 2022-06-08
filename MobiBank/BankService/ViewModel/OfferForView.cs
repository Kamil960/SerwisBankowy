using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankService.ViewModel
{
    [DataContract]
    public class OfferForView
    {
        #region Properties
        [DataMember]
        public int IdOffer { get; set; }
        [DataMember]
        public int IdAccount { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
        [DataMember]
        public DateTime? BeginingDate { get; set; }
        [DataMember]
        public DateTime? FinishDate { get; set; }

        public OfferForView(UslugaSzczegolowa offer)
        {
            IdOffer = offer.IdOferta;
            IdAccount = offer.IdRachunek;
            IsActive = offer.CzyAktywna;
            BeginingDate = offer.DataRozpoczecia;
            FinishDate = offer.DataZakonczenia;

        }
        #endregion
    }
}