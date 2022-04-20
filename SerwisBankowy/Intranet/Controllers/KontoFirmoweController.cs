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
    public class KontoFirmoweController : Controller
    {
        private readonly DataContext _context;

        public KontoFirmoweController(DataContext context)
        {
            _context = context;
        }

        // GET: KontoFirmowe
        public async Task<IActionResult> Index()
        {
            return View(await _context.KontoFirmowe.ToListAsync());
        }

        // GET: KontoFirmowe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontoFirmowe = await _context.KontoFirmowe
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (kontoFirmowe == null)
            {
                return NotFound();
            }

            return View(kontoFirmowe);
        }

        // GET: KontoFirmowe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KontoFirmowe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Grafika,Pozycja,CzyAktywna")] KontoFirmowe kontoFirmowe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontoFirmowe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kontoFirmowe);
        }

        // GET: KontoFirmowe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontoFirmowe = await _context.KontoFirmowe.FindAsync(id);
            if (kontoFirmowe == null)
            {
                return NotFound();
            }
            return View(kontoFirmowe);
        }

        // POST: KontoFirmowe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUslugaSzczegolowa,IdUsluga,Nazwa,Opis,Grafika,Pozycja,CzyAktywna")] KontoFirmowe kontoFirmowe)
        {
            if (id != kontoFirmowe.IdUslugaSzczegolowa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kontoFirmowe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontoFirmoweExists(kontoFirmowe.IdUslugaSzczegolowa))
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
            return View(kontoFirmowe);
        }

        // GET: KontoFirmowe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontoFirmowe = await _context.KontoFirmowe
                .FirstOrDefaultAsync(m => m.IdUslugaSzczegolowa == id);
            if (kontoFirmowe == null)
            {
                return NotFound();
            }

            return View(kontoFirmowe);
        }

        // POST: KontoFirmowe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kontoFirmowe = await _context.KontoFirmowe.FindAsync(id);
            _context.KontoFirmowe.Remove(kontoFirmowe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontoFirmoweExists(int id)
        {
            return _context.KontoFirmowe.Any(e => e.IdUslugaSzczegolowa == id);
        }
    }
}
