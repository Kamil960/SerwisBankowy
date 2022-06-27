using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankData.Data;
using BankData.Data.Bank;

namespace Intranet.Controllers
{
	public class KoszykController : Controller
    {
        private readonly DataContext _context;

        public KoszykController(DataContext context)
        {
            _context = context;
        }

        // GET: Koszyk
        public async Task<IActionResult> Index()
        {
              return _context.Koszyk != null ? 
                          View(await _context.Koszyk.ToListAsync()) :
                          Problem("Entity set 'DataContext.Koszyk'  is null.");
        }

        // GET: Koszyk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Koszyk == null)
            {
                return NotFound();
            }

            var koszyk = await _context.Koszyk
                .FirstOrDefaultAsync(m => m.IdKoszyk == id);
            if (koszyk == null)
            {
                return NotFound();
            }

            return View(koszyk);
        }

        // GET: Koszyk/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Koszyk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKoszyk,IdNagroda,Ilosc")] Koszyk koszyk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(koszyk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(koszyk);
        }

        // GET: Koszyk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Koszyk == null)
            {
                return NotFound();
            }

            var koszyk = await _context.Koszyk.FindAsync(id);
            if (koszyk == null)
            {
                return NotFound();
            }
            return View(koszyk);
        }

        // POST: Koszyk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKoszyk,IdNagroda,Ilosc")] Koszyk koszyk)
        {
            if (id != koszyk.IdKoszyk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(koszyk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KoszykExists(koszyk.IdKoszyk))
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
            return View(koszyk);
        }

        // GET: Koszyk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Koszyk == null)
            {
                return NotFound();
            }

            var koszyk = await _context.Koszyk
                .FirstOrDefaultAsync(m => m.IdKoszyk == id);
            if (koszyk == null)
            {
                return NotFound();
            }

            return View(koszyk);
        }

        // POST: Koszyk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Koszyk == null)
            {
                return Problem("Entity set 'DataContext.Koszyk'  is null.");
            }
            var koszyk = await _context.Koszyk.FindAsync(id);
            if (koszyk != null)
            {
                _context.Koszyk.Remove(koszyk);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KoszykExists(int id)
        {
          return (_context.Koszyk?.Any(e => e.IdKoszyk == id)).GetValueOrDefault();
        }
    }
}
