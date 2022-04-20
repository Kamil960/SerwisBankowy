using BankData.Data;
using BankData.Data.Bank;
using BankData.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalWWW.Models;
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

            return View();
        }
        public IActionResult Logowanie()
        {
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            return View();
        }
        public IActionResult AboutUs()
        {
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
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            return View();
        }
        public IActionResult Registration(int? id)
        {
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;

            if(id != null)
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
        public async Task<IActionResult> Registration([Bind("IdKlient,Login,Haslo,Imie,Nazwisko,Miejscowosc,Ulica,NrBudynku,KodPocztowy,Poczta,NrDokumentu,CzyAktywny")] Klient klient)
        {
            ViewBag.ModelStrony = this.strony;
            ViewBag.ModelListyOfert = this.uslugi;

            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction("RegistrationEdit","Home", klient);
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
        public async Task<IActionResult> RegistrationEdit([Bind("IdKlient,Login,Haslo,Imie,Nazwisko,Miejscowosc,Ulica,NrBudynku,KodPocztowy,Poczta,NrDokumentu,CzyAktywny")] Klient klient)
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
                        return RedirectToAction("Kontakt", "Home");
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
                return RedirectToAction("Index", "Home");
            }

            var klient = await _context.Klient.FindAsync(id);
            if (klient == null)
            {
                return RedirectToAction("Registration", "Home");
            }
            return View(klient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationFinal([Bind("IdKlient,Login,Haslo,Imie,Nazwisko,Miejscowosc,Ulica,NrBudynku,KodPocztowy,Poczta,NrDokumentu,CzyAktywny")] Klient klient)
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
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            var pa =
            (
                from ko in _context.KontoOsobiste
                select ko
            ).ToList();

            return View(pa);
        }
        public IActionResult CompanyAccount()
        {
            
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
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            var la =
            (
                from ko in _context.Kredyt
                select ko
            ).ToList();

            return View(la);
        }
        public IActionResult Deposit()
        {
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            var da =
            (
                from ko in _context.Lokata
                select ko
            ).ToList();

            return View(da);
        }
        public IActionResult Insurance()
        {
            ViewBag.ModelStrony = this.strony;

            ViewBag.ModelListyOfert = this.uslugi;
            var ia =
            (
                from ko in _context.Ubezpieczenie
                select ko
            ).ToList();

            return View(ia);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}