using Microsoft.EntityFrameworkCore;
using TechCareerCodeFirstUrun.Models;

namespace TechCareerCodeFirstUrun.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<Urun> Urun { get; set; }
    }
}

