using Microsoft.AspNetCore.Mvc;
using TechCareerMVCSitem.Data;
using TechCareerMVCSitem.Models;

namespace TechCareerMVCSitem.Controllers
{
    public class YeniUrunController : Controller
    {
        public ApplicationDbContext _context;
        //constructor injection - dependency 
        public YeniUrunController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<YeniUrun> urunListesi = new List<YeniUrun>();
            urunListesi = _context.YeniUrun.ToList(); //select * from Kitap 
            return View(urunListesi);
        }

        public IActionResult Details(int id)
        {
            YeniUrun urunDetay;
            urunDetay = _context.YeniUrun.Find(id); // select * from Kitap Where Id=id
            //return View(_context.Kitap.Find(id));
            return View(urunDetay);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
