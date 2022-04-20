using BankData.Data;
using Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Intranet.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            ViewBag.ModelUslugi =
            (
                from usluga in _context.Usluga
                orderby usluga.Pozycja
                select usluga
            ).ToList();
            if (id == null)
                id = _context.Usluga.First().IdUsluga;
            var item = _context.Usluga.Find(id);
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}