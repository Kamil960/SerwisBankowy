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
    public class UslugaSzczegolowaController : Controller
    {
        private readonly DataContext _context;

        public UslugaSzczegolowaController(DataContext context)
        {
            _context = context;
        }

        // GET: UslugaSzczegolowa
        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.UslugaSzczegolowa.ToListAsync());
        }

        // GET: UslugaSzczegolowa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugaSzczegolowa = await _context.UslugaSzczegolowa
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (uslugaSzczegolowa == null)
            {
                return NotFound();
            }

            return View(uslugaSzczegolowa);
        }

        // GET: UslugaSzczegolowa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UslugaSzczegolowa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUslugaSzczegolowa,Nazwa,Opis,Procent,Grafika,Pozycja,CzyAktywna")] UslugaSzczegolowa uslugaSzczegolowa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uslugaSzczegolowa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uslugaSzczegolowa);
        }

        // GET: UslugaSzczegolowa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugaSzczegolowa = await _context.UslugaSzczegolowa.FindAsync(id);
            if (uslugaSzczegolowa == null)
            {
                return NotFound();
            }
            return View(uslugaSzczegolowa);
        }

        // POST: UslugaSzczegolowa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUslugaSzczegolowa,Nazwa,Opis,Procent,Grafika,Pozycja,CzyAktywna")] UslugaSzczegolowa uslugaSzczegolowa)
        {
            if (id != uslugaSzczegolowa.IdUslugaSzczegolowa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uslugaSzczegolowa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UslugaSzczegolowaExists(uslugaSzczegolowa.IdUslugaSzczegolowa))
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
            return View(uslugaSzczegolowa);
        }

        // GET: UslugaSzczegolowa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugaSzczegolowa = await _context.UslugaSzczegolowa
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (uslugaSzczegolowa == null)
            {
                return NotFound();
            }

            return View(uslugaSzczegolowa);
        }

        // POST: UslugaSzczegolowa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uslugaSzczegolowa = await _context.UslugaSzczegolowa.FindAsync(id);
            _context.UslugaSzczegolowa.Remove(uslugaSzczegolowa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UslugaSzczegolowaExists(int id)
        {
            return _context.UslugaSzczegolowa.Any(e => e.IdUslugaSzczegolowa == id);
        }
    }
}
