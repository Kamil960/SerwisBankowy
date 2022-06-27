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
    public class UbezpieczenieController : Controller
    {
        private readonly DataContext _context;

        public UbezpieczenieController(DataContext context)
        {
            _context = context;
        }

        // GET: Ubezpieczenia
        public async Task<IActionResult> Index()
        {
              return _context.Ubezpieczenie != null ? 
                          View(await _context.Ubezpieczenie.ToListAsync()) :
                          Problem("Entity set 'DataContext.Ubezpieczenie'  is null.");
        }

        // GET: Ubezpieczenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ubezpieczenie == null)
            {
                return NotFound();
            }

            var ubezpieczenie = await _context.Ubezpieczenie
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (ubezpieczenie == null)
            {
                return NotFound();
            }

            return View(ubezpieczenie);
        }

        // GET: Ubezpieczenia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ubezpieczenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Grafika,Pozycja,LiczbaPunktow,CzyAktywna")] Ubezpieczenie ubezpieczenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ubezpieczenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ubezpieczenie);
        }

        // GET: Ubezpieczenia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ubezpieczenie == null)
            {
                return NotFound();
            }

            var ubezpieczenie = await _context.Ubezpieczenie.FindAsync(id);
            if (ubezpieczenie == null)
            {
                return NotFound();
            }
            return View(ubezpieczenie);
        }

        // POST: Ubezpieczenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Grafika,Pozycja,LiczbaPunktow,CzyAktywna")] Ubezpieczenie ubezpieczenie)
        {
            if (id != ubezpieczenie.IdUslugaSzczegolowa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ubezpieczenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UbezpieczenieExists(ubezpieczenie.IdUslugaSzczegolowa))
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
            return View(ubezpieczenie);
        }

        // GET: Ubezpieczenia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ubezpieczenie == null)
            {
                return NotFound();
            }

            var ubezpieczenie = await _context.Ubezpieczenie
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (ubezpieczenie == null)
            {
                return NotFound();
            }

            return View(ubezpieczenie);
        }

        // POST: Ubezpieczenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ubezpieczenie == null)
            {
                return Problem("Entity set 'DataContext.Ubezpieczenie'  is null.");
            }
            var ubezpieczenie = await _context.Ubezpieczenie.FindAsync(id);
            if (ubezpieczenie != null)
            {
                _context.Ubezpieczenie.Remove(ubezpieczenie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UbezpieczenieExists(int id)
        {
          return (_context.Ubezpieczenie?.Any(e => e.IdUslugaSzczegolowa == id)).GetValueOrDefault();
        }
    }
}
