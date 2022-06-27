using BankData.Data;
using BankData.Data.Bank;
using BankData.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalWWW.Models;
using RestSharp;
using System.Diagnostics;
using System.Linq;

namespace WWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly IEnumerable<Strony> strony;
        private readonly IEnumerable<Usluga> uslugi;

        public HomeController(DataContext context)
        {
            
            _context = context;
            strony =
           (
               from strona in _context.Strony
               orderby strona.Pozycja
               select strona
           ).ToList();
            uslugi =
            (
                from lista in _context.Usluga
                orderby lista.Pozycja
                select lista
            ).ToList();
            
        }
        public IActionResult Index()
        {
            var kosz =
               (
                   from k in _context.Koszyk
                   select k
               ).ToList();
            foreach (var k in kosz)
            {
                _context.Koszyk.Remove(k);
                _context.SaveChanges();
            }
            //HttpContext.Session.SetString("log", "true");
            ViewBag.ModelArt1 =
                (
                    from art1 in _context.Art1
                    select art1
                ).ToList();

            ViewBag.ModelArt2 =
                (
                    from art2 in _context.Art2
                    select art2
                ).ToList();
            ViewBag.ModelArt3 =
                (
                    from art3 in _context.Art3
                    select art3
                ).ToList();

            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;

            ViewBag.Log = HttpContext.Session.GetString("log");
            ViewBag.Points = HttpContext.Session.GetString("points");
            //if (TempData.ContainsKey("log"))
            //    Log = TempData["log"].ToString();

            return View();
        }
        public IActionResult Strony()
        {
            return View(strony);
        }
        public IActionResult Contact()
        {
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;

            ViewBag.Contact =
               (
                   from contact in _context.Kontakt
                   select contact
               ).ToList().First();
            ViewBag.Log = HttpContext.Session.GetString("log");
            ViewBag.Points = HttpContext.Session.GetString("points");
            return View();
        }
        public IActionResult Logowanie()
        {
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logowanie(string? login, string? haslo)
        {
            ViewBag.ModelStrony = this.strony;
            ViewBag.ModelListyOfert = this.uslugi;
            if (login == null || haslo == null)
            {
                return View();
            }
            foreach (var klient in _context.Klient)
            {
                if (login == klient.Login && haslo == klient.Haslo)
                {
                    HttpContext.Session.SetString("log", "true");
                    HttpContext.Session.SetString("points", klient.LiczbaPunktow.ToString());
                    HttpContext.Session.SetString("id", klient.IdKlient.ToString());
                    //TempData["log"] = "true";
                    return RedirectToAction("Index", "Home");
                }
            }
                ViewBag.Error = "Nieprawidłowy login lub hasło";
                return View();
        }
        public IActionResult Logout()
        {
            var kosz =
               (
                   from k in _context.Koszyk
                   select k
               ).ToList();
            foreach (var k in kosz)
            {
                k.CzyAktywna = false;
                _context.Update(k);
                _context.SaveChanges();
            }
            HttpContext.Session.SetString("log", "false");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AboutUs()
        {
            ViewBag.Log = HttpContext.Session.GetString("log");
            ViewBag.Points = HttpContext.Session.GetString("points");

            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            ViewBag.AboutUs =
                (
                    from onas in _context.ONas
                    select onas
                ).ToList().First();
            return View();
        }
        public IActionResult Of()
        {
            ViewBag.Log = HttpContext.Session.GetString("log");
            ViewBag.Points = HttpContext.Session.GetString("points");

            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            return View();
        }
        public IActionResult Registration(int? id)
        {
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;

            if (id != null)
            {
                id = _context.Klient.OrderBy(klient => klient.IdKlient).Last().IdKlient;
                var klient = _context.Klient.Find(id);
                _context.Klient.Remove(klient);
                _context.SaveChangesAsync();
                return View();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration([Bind("IdKlient,Login,Haslo,Imie,Nazwisko,Miejscowosc,Ulica,NrBudynku,KodPocztowy,Poczta,NrDokumentu,CzyAktywny,LiczbaPunktów")] Klient klient)
        {
            ViewBag.ModelStrony = this.strony;
            ViewBag.ModelListyOfert = this.uslugi;

            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction("RegistrationEdit", "Home", klient);
            }
            return View(klient);
        }
        public async Task<IActionResult> RegistrationEdit(int? id)
        {
            id = _context.Klient.OrderBy(klient => klient.IdKlient).Last().IdKlient;
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationEdit([Bind("IdKlient,Login,Haslo,Imie,Nazwisko,Miejscowosc,Ulica,NrBudynku,KodPocztowy,Poczta,NrDokumentu,CzyAktywny,LiczbaPunktów")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.IdKlient))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("RegistrationFinal", "Home", klient);
            }
            return View(klient);
        }
        public async Task<IActionResult> RegistrationFinal(int? id)
        {
            id = _context.Klient.OrderBy(klient => klient.IdKlient).Last().IdKlient;
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klient.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationFinal([Bind("IdKlient,Login,Haslo,Imie,Nazwisko,Miejscowosc,Ulica,NrBudynku,KodPocztowy,Poczta,NrDokumentu,CzyAktywny,LiczbaPunktów")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.IdKlient))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Logowanie", "Home");
            }
            return View(klient);
        }
        private bool KlientExists(int id)
        {
            return _context.Klient.Any(e => e.IdKlient == id);
        }
        public IActionResult PersonalAccount()
        {
            if (TempData.ContainsKey("info"))
                ViewBag.Info = TempData["info"].ToString();
            ViewBag.Log = HttpContext.Session.GetString("log");
            ViewBag.Points = HttpContext.Session.GetString("points");

            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            var pa =
            (
                from ko in _context.KontoOsobiste
                select ko
            ).ToList();

            return View(pa);
        }
        public IActionResult WybierzKonto(KontoOsobiste oferta)
        {
            if (HttpContext.Session.GetString("log") == "true")
            {
                int points = oferta.LiczbaPunktow + Int32.Parse(HttpContext.Session.GetString("points"));
                HttpContext.Session.SetString("points", points.ToString());
                var klient =
                (
                    from k in _context.Klient
                    where k.IdKlient.ToString() == HttpContext.Session.GetString("id")
                    select k
                ).FirstOrDefault();
                klient.LiczbaPunktow = Int32.Parse(HttpContext.Session.GetString("points"));
                try
                {
                    _context.Update(klient);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.IdKlient))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["info"] = "Wybranie tej oferty jest możliwe tylko dla zalogowanych użytkowników";
            return RedirectToAction("PersonalAccount", "Home");
        }
        public IActionResult CompanyAccount()
        {
            ViewBag.Log = HttpContext.Session.GetString("log");
            ViewBag.Points = HttpContext.Session.GetString("points");

            var ca =
            (
                from ko in _context.KontoFirmowe
                select ko
            ).ToList();
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            return View(ca);
        }
        public IActionResult Loan()
        {
            if (TempData.ContainsKey("info"))
                ViewBag.Info = TempData["info"].ToString();
            ViewBag.Log = HttpContext.Session.GetString("log");
            ViewBag.Points = HttpContext.Session.GetString("points");

            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            var la =
            (
                from ko in _context.Kredyt
                select ko
            ).ToList();

            return View(la);
        }
        public IActionResult WybierzKredyt(Kredyt oferta)
        {
            if (HttpContext.Session.GetString("log") == "true")
            {
                int points = oferta.LiczbaPunktow + Int32.Parse(HttpContext.Session.GetString("points"));
                HttpContext.Session.SetString("points", points.ToString());
                var klient =
                (
                    from k in _context.Klient
                    where k.IdKlient.ToString() == HttpContext.Session.GetString("id")
                    select k
                ).FirstOrDefault();
                klient.LiczbaPunktow = Int32.Parse(HttpContext.Session.GetString("points"));
                try
                {
                    _context.Update(klient);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.IdKlient))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["info"] = "Wybranie tej oferty jest możliwe tylko dla zalogowanych użytkowników";
            return RedirectToAction("Loan", "Home");
        }
        public IActionResult Deposit()
        {
            if (TempData.ContainsKey("info"))
                ViewBag.Info = TempData["info"].ToString();
            ViewBag.Log = HttpContext.Session.GetString("log");
            ViewBag.Points = HttpContext.Session.GetString("points");

            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            var da =
            (
                from ko in _context.Lokata
                select ko
            ).ToList();

            return View(da);
        }
        public IActionResult WybierzLokate(Lokata oferta)
        {
            if (HttpContext.Session.GetString("log") == "true")
            {
                int points = oferta.LiczbaPunktow + Int32.Parse(HttpContext.Session.GetString("points"));
                HttpContext.Session.SetString("points", points.ToString());
                var klient =
                (
                    from k in _context.Klient
                    where k.IdKlient.ToString() == HttpContext.Session.GetString("id")
                    select k
                ).FirstOrDefault();
                klient.LiczbaPunktow = Int32.Parse(HttpContext.Session.GetString("points"));
                try
                {
                    _context.Update(klient);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.IdKlient))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["info"] = "Wybranie tej oferty jest możliwe tylko dla zalogowanych użytkowników";
            return RedirectToAction("Deposit", "Home");
        }
        public IActionResult Insurance()
        {
            if (TempData.ContainsKey("info"))
                ViewBag.Info = TempData["info"].ToString();
            ViewBag.Log = HttpContext.Session.GetString("log");
            ViewBag.Points = HttpContext.Session.GetString("points");

            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            var ia =
            (
                from ko in _context.Ubezpieczenie
                select ko
            ).ToList();

            return View(ia);
        }
        public IActionResult WybierzUbezpieczenie(Ubezpieczenie oferta)
        {
            if (HttpContext.Session.GetString("log") == "true")
            {
                int points = oferta.LiczbaPunktow + Int32.Parse(HttpContext.Session.GetString("points"));
                HttpContext.Session.SetString("points", points.ToString());
                var klient =
                (
                    from k in _context.Klient
                    where k.IdKlient.ToString() == HttpContext.Session.GetString("id")
                    select k
                ).FirstOrDefault();
                klient.LiczbaPunktow = Int32.Parse(HttpContext.Session.GetString("points"));
                try
                {
                    _context.Update(klient);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.IdKlient))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["info"] = "Wybranie tej oferty jest możliwe tylko dla zalogowanych użytkowników";
            //HttpContext.Session.SetString("info", "Wybranie tej oferty jest możliwe tylko dla zalogowanych użytkowników");
            return RedirectToAction("Insurence", "Home");
        }
        public bool IsCorrectLogData(string login, string password)
        {
            foreach (var klient in _context.Klient)
            {
                if (login == klient.Login && password == klient.Haslo)
                    return true;
            }
            return false;

        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}