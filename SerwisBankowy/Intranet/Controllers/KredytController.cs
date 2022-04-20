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
    public class KredytController : Controller
    {
        private readonly DataContext _context;

        public KredytController(DataContext context)
        {
            _context = context;
        }

        // GET: Kredyt
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kredyt.ToListAsync());
        }

        // GET: Kredyt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kredyt = await _context.Kredyt
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (kredyt == null)
            {
                return NotFound();
            }

            return View(kredyt);
        }

        // GET: Kredyt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kredyt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Procent,Grafika,Pozycja,CzyAktywna")] Kredyt kredyt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kredyt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kredyt);
        }

        // GET: Kredyt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kredyt = await _context.Kredyt.FindAsync(id);
            if (kredyt == null)
            {
                return NotFound();
            }
            return View(kredyt);
        }

        // POST: Kredyt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Procent,Grafika,Pozycja,CzyAktywna")] Kredyt kredyt)
        {
            if (id != kredyt.IdUslugaSzczegolowa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kredyt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KredytExists(kredyt.IdUslugaSzczegolowa))
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
            return View(kredyt);
        }

        // GET: Kredyt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kredyt = await _context.Kredyt
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (kredyt == null)
            {
                return NotFound();
            }

            return View(kredyt);
        }

        // POST: Kredyt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kredyt = await _context.Kredyt.FindAsync(id);
            _context.Kredyt.Remove(kredyt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KredytExists(int id)
        {
            return _context.Kredyt.Any(e => e.IdUslugaSzczegolowa == id);
        }
    }
}
