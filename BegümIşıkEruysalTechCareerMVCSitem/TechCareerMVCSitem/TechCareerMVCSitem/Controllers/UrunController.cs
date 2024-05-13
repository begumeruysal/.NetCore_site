using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using System.Text;
using TechCareerMVCSitem.Models;

namespace TechCareerMVCSitem.Controllers
{
    public class UrunController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Urun> urunList = new List<Urun>();//models içine tanımlanan classdan çek
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7011/api/Urun"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    urunList = JsonConvert.DeserializeObject<List<Urun>>(apiResponse);

                }
            }
            return View(urunList);
        }
        public async Task<IActionResult> EditUrun(int id)
        {
            Urun duzenlenecekUrun = new Urun();
            using (var httpCilent = new HttpClient())
            {
                using (var gelenYanit = await httpCilent.GetAsync("https://localhost:7011/api/Urun/" + id))
                {
                    string gelenUrunDetayString = await gelenYanit.Content.ReadAsStringAsync();
                    duzenlenecekUrun = JsonConvert.DeserializeObject<Urun>(gelenUrunDetayString);
                }
            }

            return View(duzenlenecekUrun);
        }
        [HttpPost]
        public async Task<IActionResult> EditUrun(Urun urun)
        {
            using (var httpClient = new HttpClient())
            {

                Urun guncellenecekUrun = new Urun()
                {
                    Id = urun.Id,
                    UrunAdi = urun.UrunAdi,
                    Fiyati = urun.Fiyati,
                    
                };
                httpClient.BaseAddress = new Uri("https://localhost:7011/");
                var response = httpClient.PutAsJsonAsync("api/Urun", guncellenecekUrun).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Urun");
                }
                else
                {
                    return NotFound();
                }
            }
        }

        public ViewResult UrunEkle() => View();

        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urun urun)
        {
            Urun eklenecekUrun = new Urun();
            using (HttpClient httpClient = new HttpClient())
            {
                StringContent serializeEdilecekUrun = new StringContent(JsonConvert.SerializeObject(urun), Encoding.UTF8, "application/json");
                //{"KitapAdi",kitap.KitapAdi,"Fiyati":kitap.Fiyati}
                using (var response = await httpClient.PostAsync("https://localhost:7011/api/Urun", serializeEdilecekUrun))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Urun");
                    }
                    else
                    {
                        return NotFound();
                    }
                }


            }

        }


        [HttpGet]
        public async Task<IActionResult> GetUrun(int id)
        {
            Urun detayUrun = new Urun();
            using (var httpClient = new HttpClient())
            {
                using (var gelenYanit = await httpClient.GetAsync("https://localhost:7011/api/Urun/" + id))
                {
                    string gelenUrunDetayString = await gelenYanit.Content.ReadAsStringAsync();
                    detayUrun = JsonConvert.DeserializeObject<Urun>(gelenUrunDetayString);
                }
            }

            return View(detayUrun);
        }


        public async Task<IActionResult> DeleteUrun(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var gelenYanit = await httpClient.DeleteAsync("https://localhost:7011/api/Urun/" + id))
                {
                    string abc = await gelenYanit.Content.ReadAsStringAsync();
                }
                return RedirectToAction("Index");
            }
        }
    }
}

