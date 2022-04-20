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
    public class StronyController : Controller
    {
        private readonly DataContext _context;

        public StronyController(DataContext context)
        {
            _context = context;
        }

        // GET: Strony
        public async Task<IActionResult> Index()
        {
            return View(await _context.Strony.ToListAsync());
        }

        // GET: Strony/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strony = await _context.Strony
                .FirstOrDefaultAsync(m => m.IdStrony == id);
            if (strony == null)
            {
                return NotFound();
            }

            return View(strony);
        }

        // GET: Strony/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Strony/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStrony,Nazwa,Pozycja")] Strony strony)
        {
            if (ModelState.IsValid)
            {
                _context.Add(strony);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(strony);
        }

        // GET: Strony/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strony = await _context.Strony.FindAsync(id);
            if (strony == null)
            {
                return NotFound();
            }
            return View(strony);
        }

        // POST: Strony/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStrony,Nazwa,Pozycja")] Strony strony)
        {
            if (id != strony.IdStrony)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strony);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronyExists(strony.IdStrony))
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
            return View(strony);
        }

        // GET: Strony/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strony = await _context.Strony
                .FirstOrDefaultAsync(m => m.IdStrony == id);
            if (strony == null)
            {
                return NotFound();
            }

            return View(strony);
        }

        // POST: Strony/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var strony = await _context.Strony.FindAsync(id);
            _context.Strony.Remove(strony);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronyExists(int id)
        {
            return _context.Strony.Any(e => e.IdStrony == id);
        }
    }
}
