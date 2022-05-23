using BankService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService.Services.Offer
{
    public class OfferService : BankEntity, IOfferService
    {
        #region Properties
        List<UslugaSzczegolowa> _offer;
        #endregion
        #region Constructor
        public OfferService():base()
        {
            _offer = (from offer in _mobileBank.UslugaSzczegolowa select offer).ToList();   
        }
        #endregion
        public List<OfferForView> GetOfferByDate()
        {
            return GetOfferForViews().OrderByDescending(_offer => _offer.FinishDate).ToList();
        }
        public List<OfferForView> GetOfferForViews()
        {
            return _offer.Select(_offer => new OfferForView(_offer)).ToList();
        }
    }
}
