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
    public class LokataController : Controller
    {
        private readonly DataContext _context;

        public LokataController(DataContext context)
        {
            _context = context;
        }

        // GET: Lokata
        public async Task<IActionResult> Index()
        {
              return _context.Lokata != null ? 
                          View(await _context.Lokata.ToListAsync()) :
                          Problem("Entity set 'DataContext.Lokata'  is null.");
        }

        // GET: Lokata/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lokata == null)
            {
                return NotFound();
            }

            var lokata = await _context.Lokata
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (lokata == null)
            {
                return NotFound();
            }

            return View(lokata);
        }

        // GET: Lokata/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lokata/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Procent,Grafika,Pozycja,CzyAktywna,LiczbaPunktow")] Lokata lokata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokata);
        }

        // GET: Lokata/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lokata == null)
            {
                return NotFound();
            }

            var lokata = await _context.Lokata.FindAsync(id);
            if (lokata == null)
            {
                return NotFound();
            }
            return View(lokata);
        }

        // POST: Lokata/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Procent,Grafika,Pozycja,CzyAktywna,LiczbaPunktow")] Lokata lokata)
        {
            if (id != lokata.IdUslugaSzczegolowa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokataExists(lokata.IdUslugaSzczegolowa))
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
            return View(lokata);
        }

        // GET: Lokata/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lokata == null)
            {
                return NotFound();
            }

            var lokata = await _context.Lokata
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (lokata == null)
            {
                return NotFound();
            }

            return View(lokata);
        }

        // POST: Lokata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lokata == null)
            {
                return Problem("Entity set 'DataContext.Lokata'  is null.");
            }
            var lokata = await _context.Lokata.FindAsync(id);
            if (lokata != null)
            {
                _context.Lokata.Remove(lokata);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokataExists(int id)
        {
          return (_context.Lokata?.Any(e => e.IdUslugaSzczegolowa == id)).GetValueOrDefault();
        }
    }
}
