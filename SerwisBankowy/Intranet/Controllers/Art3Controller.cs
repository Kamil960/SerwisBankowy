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
    public class Art3Controller : Controller
    {
        private readonly DataContext _context;

        public Art3Controller(DataContext context)
        {
            _context = context;
        }

        // GET: Art3
        public async Task<IActionResult> Index()
        {
            return View(await _context.Art3.ToListAsync());
        }

        // GET: Art3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art3 = await _context.Art3
                .FirstOrDefaultAsync(m => m.IdArt3 == id);
            if (art3 == null)
            {
                return NotFound();
            }

            return View(art3);
        }

        // GET: Art3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Art3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArt3,Tytul,Tresc1,Tresc2,PozGieldowa1,PozGieldowa2,PozGieldowa3,PozGieldowa4,Grafika,CrypTytul,Crypto1,Crypto2,Crypto3,Crypto4,CrypIcon1,CrypIcon2,CrypIcon3,CrypIcon4")] Art3 art3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(art3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(art3);
        }

        // GET: Art3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art3 = await _context.Art3.FindAsync(id);
            if (art3 == null)
            {
                return NotFound();
            }
            return View(art3);
        }

        // POST: Art3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArt3,Tytul,Tresc1,Tresc2,PozGieldowa1,PozGieldowa2,PozGieldowa3,PozGieldowa4,Grafika,CrypTytul,Crypto1,Crypto2,Crypto3,Crypto4,CrypIcon1,CrypIcon2,CrypIcon3,CrypIcon4")] Art3 art3)
        {
            if (id != art3.IdArt3)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(art3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Art3Exists(art3.IdArt3))
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
            return View(art3);
        }

        // GET: Art3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art3 = await _context.Art3
                .FirstOrDefaultAsync(m => m.IdArt3 == id);
            if (art3 == null)
            {
                return NotFound();
            }

            return View(art3);
        }

        // POST: Art3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var art3 = await _context.Art3.FindAsync(id);
            _context.Art3.Remove(art3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Art3Exists(int id)
        {
            return _context.Art3.Any(e => e.IdArt3 == id);
        }
    }
}
