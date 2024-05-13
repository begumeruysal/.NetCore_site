using System.ComponentModel.DataAnnotations;

namespace TechCareerMVCSitem.Models
{
    public class Sepet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string urunAdi { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public decimal fiyat { get; set; }
    }
}
