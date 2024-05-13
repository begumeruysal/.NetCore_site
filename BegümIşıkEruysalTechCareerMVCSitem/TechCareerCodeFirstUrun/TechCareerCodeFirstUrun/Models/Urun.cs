using System.ComponentModel.DataAnnotations;

namespace TechCareerCodeFirstUrun.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UrunAdi { get; set; }
        [Required]
        public double Fiyati { get; set; }
    }
}
