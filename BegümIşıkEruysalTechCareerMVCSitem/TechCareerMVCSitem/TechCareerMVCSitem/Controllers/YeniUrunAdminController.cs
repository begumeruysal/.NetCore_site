using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCareerMVCSitem.Data;
using TechCareerMVCSitem.Models;
using TechCareerMVCSitem.ViewModels;

namespace TechCareerMVCSitem.Controllers
{
    public class YeniUrunAdminController : Controller
    {
        public ApplicationDbContext _context;
        public IWebHostEnvironment _environment;

        public YeniUrunAdminController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            List<YeniUrun> urunListesi = new List<YeniUrun>();
            urunListesi = await _context.YeniUrun.ToListAsync(); //select * from Kitap 
            return View(urunListesi);
        }

        //bu metod ekranı oluşturan metod 
        public IActionResult Create()
        {
            return View();
        }

        //bu metodda ekrandan girilen değerleri alıp işleyecek metodumuz
        [HttpPost]
        public async Task<IActionResult> Create(UrunViewModel model)
        {
            try
            {
                //if(ModelState.IsValid)
                //{
                string yuklenenResimAdi = ResimYukle(model);
                YeniUrun urun = new YeniUrun
                {
                    urunAdi = model.urunAdi,
                    ISBN = model.ISBN,
                    fiyat = model.fiyat,
                    urunResim = yuklenenResimAdi,
                    yayinlanmaTarihi = model.yayinlanmaTarihi
                };

                _context.Add(urun); //insert into
                await _context.SaveChangesAsync(); // oluşturulan insert kodunu sqlserver execute edecek
                return RedirectToAction(nameof(Index));
                // }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction(nameof(Index));
        }
        private string ResimYukle(UrunViewModel model)
        {
            string dosyaAdi = "";
            string dosyaninYuklenecegiKlasorYolu = Path.Combine(_environment.WebRootPath, "Uploads");

            if (!Directory.Exists(dosyaninYuklenecegiKlasorYolu))
            {
                Directory.CreateDirectory(dosyaninYuklenecegiKlasorYolu);
            }

            if (model.UrunPicture.FileName != null)
            {
                dosyaAdi = model.UrunPicture.FileName;
                string filePath = Path.Combine(dosyaninYuklenecegiKlasorYolu, dosyaAdi);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    //seçilen resim ilgili klasörü ilgili ismi ile birlikte oluşturulur
                    model.UrunPicture.CopyTo(fileStream);
                }

            }
            return dosyaAdi;
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urunDetay = await _context.YeniUrun.FindAsync(id);

            UrunViewModel urunViewModel = new()
            {
                urunAdi = urunDetay.urunAdi,
                ISBN = urunDetay.ISBN,
                fiyat = urunDetay.fiyat,
                yayinlanmaTarihi = urunDetay.yayinlanmaTarihi,
                urunResim = urunDetay.urunResim


            };
            return View(urunViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UrunViewModel model)
        {
            var urun= await _context.YeniUrun.FindAsync(model.Id);
            
            //düzenleme sayfasında bir başka resim seçtiysem kontrolünü yapmam gerekiyro
            if (model.UrunPicture != null)
            {
                //resmini değiştirmek istediğim ürünün database deki kitapResim kolonundaki adına göre
                // git wwwroot klasörü altındaki Uploads klasöründeki ilgili resmi bul ve sil
                //string filePath = Path.Combine(_environment.WebRootPath, "Uploads", urun.urunResim);
                //System.IO.File.Delete(filePath);
                urun.urunAdi = model.urunAdi;
                urun.ISBN = model.ISBN;
                urun.fiyat = model.fiyat;
                urun.yayinlanmaTarihi = model.yayinlanmaTarihi;
                string guncellenenYuklenenResimAdi = ResimYukle(model);
                urun.urunResim = guncellenenYuklenenResimAdi;

                _context.YeniUrun.Update(urun);
                try
                {
                    await _context.SaveChangesAsync(); //update 
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //select * from Kitap where Id=id
            var urun = await _context.YeniUrun
                .FirstOrDefaultAsync(m => m.Id == id);

            string filePath = Path.Combine(_environment.WebRootPath, "Uploads", urun.urunResim);
            System.IO.File.Delete(filePath);
            _context.YeniUrun.Remove(urun);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

