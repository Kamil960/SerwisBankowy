using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankData.Data;
using BankData.Data.CMS;

namespace Intranet.Controllers
{
    public class ListaNagrodController : Controller
    {
        private readonly DataContext _context;

        public ListaNagrodController(DataContext context)
        {
            _context = context;
        }

        // GET: ListaNagrod
        public async Task<IActionResult> Index()
        {
              return _context.ListaNagrod != null ? 
                          View(await _context.ListaNagrod.ToListAsync()) :
                          Problem("Entity set 'DataContext.ListaNagrod'  is null.");
        }

        // GET: ListaNagrod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListaNagrod == null)
            {
                return NotFound();
            }

            var listaNagrod = await _context.ListaNagrod
                .FirstOrDefaultAsync(m => m.IdElementu == id);
            if (listaNagrod == null)
            {
                return NotFound();
            }

            return View(listaNagrod);
        }

        // GET: ListaNagrod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListaNagrod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdElementu,Nazwa,Pozycja")] ListaNagrod listaNagrod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaNagrod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaNagrod);
        }

        // GET: ListaNagrod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListaNagrod == null)
            {
                return NotFound();
            }

            var listaNagrod = await _context.ListaNagrod.FindAsync(id);
            if (listaNagrod == null)
            {
                return NotFound();
            }
            return View(listaNagrod);
        }

        // POST: ListaNagrod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdElementu,Nazwa,Pozycja")] ListaNagrod listaNagrod)
        {
            if (id != listaNagrod.IdElementu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaNagrod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaNagrodExists(listaNagrod.IdElementu))
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
            return View(listaNagrod);
        }

        // GET: ListaNagrod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListaNagrod == null)
            {
                return NotFound();
            }

            var listaNagrod = await _context.ListaNagrod
                .FirstOrDefaultAsync(m => m.IdElementu == id);
            if (listaNagrod == null)
            {
                return NotFound();
            }

            return View(listaNagrod);
        }

        // POST: ListaNagrod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListaNagrod == null)
            {
                return Problem("Entity set 'DataContext.ListaNagrod'  is null.");
            }
            var listaNagrod = await _context.ListaNagrod.FindAsync(id);
            if (listaNagrod != null)
            {
                _context.ListaNagrod.Remove(listaNagrod);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaNagrodExists(int id)
        {
          return (_context.ListaNagrod?.Any(e => e.IdElementu == id)).GetValueOrDefault();
        }
    }
}
