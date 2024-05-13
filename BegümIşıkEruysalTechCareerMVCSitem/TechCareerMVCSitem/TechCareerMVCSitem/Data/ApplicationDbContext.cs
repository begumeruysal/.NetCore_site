
using Microsoft.EntityFrameworkCore;
using TechCareerMVCSitem.Models;

namespace TechCareerMVCSitem.Data
{
   
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<YeniUrun> YeniUrun { get; set; }
    }
}
