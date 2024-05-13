using System.ComponentModel.DataAnnotations;

namespace TechCareerMVCSitem.ViewModels
{
    public class UrunViewModel : EditImageViewModel
    {
        [Required]
        public string urunAdi { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public decimal fiyat { get; set; }

        [Required]
        public string urunResim { get; set; }

        [Required]
        public string yayinlanmaTarihi { get; set; }
    }
}
