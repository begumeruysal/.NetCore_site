using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCareerCodeFirstUrun.Data;
using TechCareerCodeFirstUrun.Models;

namespace TechCareerCodeFirstUrun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        ApplicationDbContext _context;

        
        public UrunController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urun>>> UrunleriGetir()
        {
            //
            List<Urun> urunListesi;
            // 
            urunListesi = await _context.Urun.ToListAsync();

            return urunListesi;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Urun>>> UrunEkle(Urun urun)
        {
            try
            {
                _context.Urun.Add(urun); //insert into 
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok();//200
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Urun>> UrunDetayGetir(int id)
        {
            // select * from Urun where Id=id
            var urun = await _context.Urun.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            return urun;
        }
        [HttpPut]

        public async Task<ActionResult<IEnumerable<Urun>>> UrunGuncelle(Urun urun)
        {
            _context.Entry(urun).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync(); //update 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()
                    );
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Urun>> UrunSil(int id)
        {
            Urun silinecekUrun = await _context.Urun.FindAsync(id);
            _context.Urun.Remove(silinecekUrun);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}

