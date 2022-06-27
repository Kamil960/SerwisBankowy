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
    public class NagrodyController : Controller
    {
        private readonly DataContext _context;

        public NagrodyController(DataContext context)
        {
            _context = context;
        }

        // GET: Nagrody
        public async Task<IActionResult> Index()
        {
              return _context.Nagrody != null ? 
                          View(await _context.Nagrody.ToListAsync()) :
                          Problem("Entity set 'DataContext.Nagrody'  is null.");
        }

        // GET: Nagrody/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nagrody == null)
            {
                return NotFound();
            }

            var nagrody = await _context.Nagrody
                .FirstOrDefaultAsync(m => m.IdNagrody == id);
            if (nagrody == null)
            {
                return NotFound();
            }

            return View(nagrody);
        }

        // GET: Nagrody/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nagrody/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNagrody,LiczbaPunktow,Nazwa,Grafika,Kategoria,CzyAktywna")] Nagrody nagrody)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nagrody);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nagrody);
        }

        // GET: Nagrody/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nagrody == null)
            {
                return NotFound();
            }

            var nagrody = await _context.Nagrody.FindAsync(id);
            if (nagrody == null)
            {
                return NotFound();
            }
            return View(nagrody);
        }

        // POST: Nagrody/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNagrody,LiczbaPunktow,Nazwa,Grafika,Kategoria,CzyAktywna")] Nagrody nagrody)
        {
            if (id != nagrody.IdNagrody)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nagrody);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NagrodyExists(nagrody.IdNagrody))
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
            return View(nagrody);
        }

        // GET: Nagrody/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nagrody == null)
            {
                return NotFound();
            }

            var nagrody = await _context.Nagrody
                .FirstOrDefaultAsync(m => m.IdNagrody == id);
            if (nagrody == null)
            {
                return NotFound();
            }

            return View(nagrody);
        }

        // POST: Nagrody/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nagrody == null)
            {
                return Problem("Entity set 'DataContext.Nagrody'  is null.");
            }
            var nagrody = await _context.Nagrody.FindAsync(id);
            if (nagrody != null)
            {
                _context.Nagrody.Remove(nagrody);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NagrodyExists(int id)
        {
          return (_context.Nagrody?.Any(e => e.IdNagrody == id)).GetValueOrDefault();
        }
    }
}
