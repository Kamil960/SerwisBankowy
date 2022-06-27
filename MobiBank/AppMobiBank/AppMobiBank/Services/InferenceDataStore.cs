using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMobiBank.Services
{
    public class InferenceDataStore : ItemDataStore<Inference>
    {
        public List<Inference> inf;

        public InferenceDataStore():base()
        {
            inf = new List<Inference>();
            inf.Add(new Inference { IdOffer = 1, Type = "kredyt", Name = "Chwilówka", Description = "abc", Image = "https://www.viasms.pl/themes/main/images/kredyty-chwilowki/08_a.jpg"});
            inf.Add(new Inference { IdOffer = 2, Type = "kredyt", Name = "Prosto liczony", Description = "abc", Image = "https://images.direct.money.pl/articles/thumb/606x287_fit_in_77fe57c956c30578643cc2e94da2b5fb.jpeg" });
            inf.Add(new Inference { IdOffer = 3, Type = "kredyt", Name = "Hipoteczny", Description = "abc", Image = "https://thumbs.rynekpierwotny.pl/2fafa89d:56wpBNMFmez41HqXGvGLz360Nqs/1160x638/filters:upscale():format(jpg)/articles/gallery/image/10569/kredyt-hipoteczny_a1a621.jpg" });

            inf.Add(new Inference { IdOffer = 4, Type = "lokata", Name = "Szybka", Description = "abc", Image = "https://beskidzka24.pl/wp-content/uploads/2020/06/20200608134818_54e6dc454850a414f6da8c7dda79367a1c36d8e35b556c4870267ad29748c65cb0_1280.jpg-1170x663.jpg" });
            inf.Add(new Inference { IdOffer = 5, Type = "lokata", Name = "Pewna", Description = "abc", Image = "https://vkl.pl/uploads/images/pageimg/kredyty-konsolidacyjny-dla-osob-indywidualnych.jpg" });
            inf.Add(new Inference { IdOffer = 6, Type = "lokata", Name = "Warto poczekać", Description = "abc", Image = "https://s3.eu-central-1.amazonaws.com/porowneo-media-test/medias/2017/04/kiedy-warto-sie-starac-o-kredyt-inwestycyjny.jpg" });

            inf.Add(new Inference { IdOffer = 7, Type = "ubezpieczenie", Name = "W zdrowiu i chorobie", Description = "abc", Image = "https://www.uniqa.pl/files/_processed_/8/5/csm_oc-w-zyciu-prywatnym_optimized_dec73176bf.jpg" });
            inf.Add(new Inference { IdOffer = 8, Type = "ubezpieczenie", Name = "W razie wypadku", Description = "abc", Image = "https://d2yvmenv39glx3.cloudfront.net/images/f-105726-co-to-jest-ubezpieczenie-ac-i-co-wchodzi-w-jego-zakres.jpg" });
            inf.Add(new Inference { IdOffer = 9, Type = "ubezpieczenie", Name = "Gdy płonie dobytek", Description = "abc", Image = "https://eurofinance.info.pl/wp-content/uploads/2021/10/ubezpieczenie-mieskzania-i-domu-od-po%C5%BCaru.jpg" });
        }

        public override Inference Find(Inference item)
        {
            throw new NotImplementedException();
        }

        public override Inference Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
