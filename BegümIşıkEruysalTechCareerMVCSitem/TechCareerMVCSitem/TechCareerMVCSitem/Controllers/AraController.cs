using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechCareerMVCSitem.Data;
using TechCareerMVCSitem.Models;

public class AraController : Controller
{
    private readonly ApplicationDbContext _context;

    public AraController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string q)
    {
        if (string.IsNullOrEmpty(q))
        {
            ViewBag.SearchQuery = "Arama yapılmadı.";
            return View();
        }

        var products = _context.YeniUrun.Where(p => p.urunAdi.Contains(q)).ToList();

        if (products.Any())
        {
            return View("Index", "YeniUrun");
        }
        else
        {
            ViewBag.SearchQuery = "Ürün bulunamadı.";
            return View();
        }
    }

}
