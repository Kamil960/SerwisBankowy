using BankData.Data;
using BankData.Data.Bank;
using BankData.Data.CMS;
using Microsoft.AspNetCore.Mvc;

namespace PortalWWW.Controllers
{
    public class GiftsController : Controller
    {
        private readonly DataContext _context;
        private readonly IEnumerable<ListaNagrod> listaNagrod;
        public GiftsController(DataContext context)
        {
            this._context = context;
            listaNagrod =
            (
                from ln in _context.ListaNagrod
                orderby ln.Pozycja
                select ln
            ).ToList();
        }
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.Points = HttpContext.Session.GetString("points");
            ViewBag.ModelListyNagrod = listaNagrod;
            ViewBag.Nagrody =
            (
                from n in _context.Nagrody
                where n.Kategoria == "1"
                select n
            ).ToList().First();
            return View();
        }
        public IActionResult RodzajeNagrod()
        {
            ViewBag.Points = HttpContext.Session.GetString("points");
            return View(listaNagrod);
        }
        public IActionResult Prezenty()
        {
            ViewBag.Points = HttpContext.Session.GetString("points");
            ViewBag.ModelListyNagrod = listaNagrod;
            ViewBag.Nagrody =
            (
                from n in _context.Nagrody
                where n.Kategoria == "2"
                select n
            ).ToList();
            return View();
        }
        public IActionResult Upominki()
        {
            ViewBag.Points = HttpContext.Session.GetString("points");
            ViewBag.ModelListyNagrod = listaNagrod;
            ViewBag.Nagrody =
            (
                from n in _context.Nagrody
                where n.Kategoria == "3"
                select n
            ).ToList();
            return View();
        }
        public IActionResult Drobiazgi()
        {
            ViewBag.Points = HttpContext.Session.GetString("points");
            ViewBag.ModelListyNagrod = listaNagrod;
            ViewBag.Nagrody =
            (
                from n in _context.Nagrody
                where n.Kategoria == "4"
                select n
            ).ToList();
            return View();
        }
        public IActionResult Koszyk()
        {
            if (TempData.ContainsKey("info"))
                ViewBag.Info2 = TempData["info"].ToString();

            ViewBag.Points = HttpContext.Session.GetString("points");
            ViewBag.ModelListyNagrod = listaNagrod;

            var koszyk =
            (
                from k in _context.Koszyk
                where k.CzyAktywna == true
                select k
            ).ToList();
            if (koszyk.Count <= 0)
            {
                ViewBag.Info = "Koszyk jest pusty";
                ViewBag.Nagrody = null;
            }
            else
            {
                ViewBag.Info = "Koszyk";
                ViewBag.Nagrody = koszyk;
                int Suma = 0;
                foreach (var k in koszyk)
                    Suma += k.LiczbaPunktow;
                ViewBag.Suma = Suma;
                TempData["SumaPunktow"] = Suma.ToString();
            }
            return View();
        }
        public IActionResult Wybierz(int id)
        {
            var kosz =
            (
                from k in _context.Koszyk
                select k
            ).ToList();
            var nagroda =
            (
                from n in _context.Nagrody
                where n.IdNagrody == id
                select n
            ).FirstOrDefault();
            if (kosz.Count != 0)
            {
                foreach (var k in kosz)
                {
                    if (k.IdNagroda == id && k.CzyAktywna == true)
                    {
                        k.Ilosc++;
                        k.LiczbaPunktow *= k.Ilosc;
                        _context.Update(k);
                        _context.SaveChanges();
                        return RedirectToAction("Koszyk", "Gifts");
                    }
                }
            }
            Koszyk koszyk = new Koszyk
            {
                IdNagroda = id,
                Ilosc = 1,
                LiczbaPunktow = nagroda.LiczbaPunktow,
                Nazwa = nagroda.Nazwa,
                Grafika = nagroda.Grafika,
                Kategoria = nagroda.Kategoria,
                CzyAktywna = true
            };
            _context.Add(koszyk);
            _context.SaveChanges();
            return RedirectToAction("Koszyk", "Gifts");
        }
        public IActionResult Usun(int id)
        {
            var nagrodaPunkty =
            (
                from n in _context.Nagrody
                where n.IdNagrody == id
                select n.LiczbaPunktow
            ).First();
            var kosz =
            (
                from k in _context.Koszyk
                where k.IdNagroda == id
                select k
            ).First();
            kosz.Ilosc--;
            kosz.LiczbaPunktow = kosz.Ilosc * nagrodaPunkty;
            if (kosz.Ilosc > 0)
                _context.Update(kosz);
            else
			{
                kosz.CzyAktywna = false; 
                _context.Update(kosz);
			}
            _context.SaveChanges();
            return RedirectToAction("Koszyk", "Gifts");
        }
        public IActionResult Dodaj(int id)
		{
            var nagrodaPunkty =
            (
                from n in _context.Nagrody
                where n.IdNagrody == id
                select n.LiczbaPunktow
            ).First();
            var kosz =
            (
                from k in _context.Koszyk
                where k.IdNagroda == id
                select k
            ).First();
            kosz.Ilosc++;
            kosz.LiczbaPunktow = kosz.Ilosc * nagrodaPunkty;
            _context.Update(kosz);
            _context.SaveChanges();
            return RedirectToAction("Koszyk", "Gifts");
        }
        public IActionResult UsunCalkiem(int id)
        {
            var nagrodaPunkty =
            (
                from n in _context.Nagrody
                where n.IdNagrody == id
                select n.LiczbaPunktow
            ).First();
            var kosz =
            (
                from k in _context.Koszyk
                where k.IdNagroda == id
                select k
            ).First();
            kosz.LiczbaPunktow = kosz.Ilosc * nagrodaPunkty;
            kosz.CzyAktywna = false;
            _context.Update(kosz);
            _context.SaveChanges();
            return RedirectToAction("Koszyk", "Gifts");
        }
        public IActionResult Zrealizuj()
        {
            int suma = 0;
            if (TempData.ContainsKey("SumaPunktow"))
            {
                suma = Int32.Parse(TempData["SumaPunktow"].ToString());
            }
            int liczbaPunktowUzytkownika = Int32.Parse(HttpContext.Session.GetString("points"));

            if (liczbaPunktowUzytkownika >= suma)
            {
                var kosz =
                (
                    from k in _context.Koszyk
                    where k.CzyAktywna == true
                    select k
                ).ToList();
                foreach (var k in kosz)
                {
                    k.CzyAktywna = false;
                    _context.Update(k);
                    _context.SaveChanges();
                }
                int id = Int32.Parse(HttpContext.Session.GetString("id"));
                var klient =
                (
                    from k in _context.Klient
                    where k.IdKlient == id
                    select k
                ).First();
                klient.LiczbaPunktow = liczbaPunktowUzytkownika - suma;
                _context.Update(klient);
                _context.SaveChanges();
                HttpContext.Session.SetString("points", (liczbaPunktowUzytkownika - suma).ToString());
            }

            else
                TempData["info"] = "Nie masz dość punktów by zrealizować zamówienie";
            return RedirectToAction("Koszyk", "Gifts");
        }
    }
}

