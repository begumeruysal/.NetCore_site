using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechCareerMVCSitem.Data;
using TechCareerMVCSitem.Models;

namespace TechCareerMVCSitem.Controllers
{
    public class SepetController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static List<Sepet> sepet = new List<Sepet>();

        public SepetController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(sepet);
        }

        public IActionResult SepeteEkle(int id)
        {
            var urun = _context.YeniUrun.FirstOrDefault(x => x.Id == id);
            if (urun != null)
            {
                sepet.Add(new Sepet
                {
                    Id = urun.Id,
                    urunAdi = urun.urunAdi,
                    ISBN = urun.ISBN,
                    fiyat = urun.fiyat
                });
            }

            return RedirectToAction("Index", "Sepet");
        }

        public IActionResult Delete(int id)
        {
            var urun = sepet.FirstOrDefault(x => x.Id == id);
            if (urun != null)
            {
                sepet.Remove(urun);
            }
            return RedirectToAction("Index");
        }
    }

}
