using System.ComponentModel.DataAnnotations;

namespace TechCareerMVCSitem.Models
{
    public class YeniUrun
    {
        [Key]
        public int Id { get; set; }

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
