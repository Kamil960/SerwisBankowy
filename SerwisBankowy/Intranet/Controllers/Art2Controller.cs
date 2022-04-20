#nullable disable
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
    public class Art2Controller : Controller
    {
        private readonly DataContext _context;

        public Art2Controller(DataContext context)
        {
            _context = context;
        }

        // GET: Art2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Art2.ToListAsync());
        }

        // GET: Art2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art2 = await _context.Art2
                .FirstOrDefaultAsync(m => m.IdArt2 == id);
            if (art2 == null)
            {
                return NotFound();
            }

            return View(art2);
        }

        // GET: Art2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Art2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArt2,Tytul,Tresc1,Tresc2,Grafika")] Art2 art2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(art2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(art2);
        }

        // GET: Art2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art2 = await _context.Art2.FindAsync(id);
            if (art2 == null)
            {
                return NotFound();
            }
            return View(art2);
        }

        // POST: Art2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArt2,Tytul,Tresc1,Tresc2,Grafika")] Art2 art2)
        {
            if (id != art2.IdArt2)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(art2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Art2Exists(art2.IdArt2))
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
            return View(art2);
        }

        // GET: Art2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art2 = await _context.Art2
                .FirstOrDefaultAsync(m => m.IdArt2 == id);
            if (art2 == null)
            {
                return NotFound();
            }

            return View(art2);
        }

        // POST: Art2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var art2 = await _context.Art2.FindAsync(id);
            _context.Art2.Remove(art2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Art2Exists(int id)
        {
            return _context.Art2.Any(e => e.IdArt2 == id);
        }
    }
}
