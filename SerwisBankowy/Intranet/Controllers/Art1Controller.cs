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
    public class Art1Controller : Controller
    {
        private readonly DataContext _context;

        public Art1Controller(DataContext context)
        {
            _context = context;
        }

        // GET: Art1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Art1.ToListAsync());
        }

        // GET: Art1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art1 = await _context.Art1
                .FirstOrDefaultAsync(m => m.IdArt1 == id);
            if (art1 == null)
            {
                return NotFound();
            }

            return View(art1);
        }

        // GET: Art1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Art1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArt1,Tytul,Nazwa1,Nazwa2,Nazwa3,Grafika1,Grafika2,Grafika3,Opis1,Opis2,Opis3,Podsumowanie")] Art1 art1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(art1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(art1);
        }

        // GET: Art1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art1 = await _context.Art1.FindAsync(id);
            if (art1 == null)
            {
                return NotFound();
            }
            return View(art1);
        }

        // POST: Art1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArt1,Tytul,Nazwa1,Nazwa2,Nazwa3,Grafika1,Grafika2,Grafika3,Opis1,Opis2,Opis3,Podsumowanie")] Art1 art1)
        {
            if (id != art1.IdArt1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(art1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Art1Exists(art1.IdArt1))
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
            return View(art1);
        }

        // GET: Art1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art1 = await _context.Art1
                .FirstOrDefaultAsync(m => m.IdArt1 == id);
            if (art1 == null)
            {
                return NotFound();
            }

            return View(art1);
        }

        // POST: Art1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var art1 = await _context.Art1.FindAsync(id);
            _context.Art1.Remove(art1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Art1Exists(int id)
        {
            return _context.Art1.Any(e => e.IdArt1 == id);
        }
    }
}
