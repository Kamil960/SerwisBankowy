#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankData.Data;
using BankData.Data.Bank;

namespace Intranet.Controllers
{
    public class KontoOsobisteController : Controller
    {
        private readonly DataContext _context;

        public KontoOsobisteController(DataContext context)
        {
            _context = context;
        }

        // GET: KontoOsobiste
        public async Task<IActionResult> Index()
        {
            return View(await _context.KontoOsobiste.ToListAsync());
        }

        // GET: KontoOsobiste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontoOsobiste = await _context.KontoOsobiste
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (kontoOsobiste == null)
            {
                return NotFound();
            }

            return View(kontoOsobiste);
        }

        // GET: KontoOsobiste/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KontoOsobiste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Grafika,Pozycja,CzyAktywna")] KontoOsobiste kontoOsobiste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontoOsobiste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kontoOsobiste);
        }

        // GET: KontoOsobiste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontoOsobiste = await _context.KontoOsobiste.FindAsync(id);
            if (kontoOsobiste == null)
            {
                return NotFound();
            }
            return View(kontoOsobiste);
        }

        // POST: KontoOsobiste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Grafika,Pozycja,CzyAktywna")] KontoOsobiste kontoOsobiste)
        {
            if (id != kontoOsobiste.IdUslugaSzczegolowa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kontoOsobiste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontoOsobisteExists(kontoOsobiste.IdUslugaSzczegolowa))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kontoOsobiste);
        }

        // GET: KontoOsobiste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontoOsobiste = await _context.KontoOsobiste
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (kontoOsobiste == null)
            {
                return NotFound();
            }

            return View(kontoOsobiste);
        }

        // POST: KontoOsobiste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kontoOsobiste = await _context.KontoOsobiste.FindAsync(id);
            _context.KontoOsobiste.Remove(kontoOsobiste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontoOsobisteExists(int id)
        {
            return _context.KontoOsobiste.Any(e => e.IdUslugaSzczegolowa == id);
        }
    }
}
