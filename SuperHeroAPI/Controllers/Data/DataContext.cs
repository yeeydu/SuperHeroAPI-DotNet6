using Microsoft.EntityFrameworkCore;


// install EntityFrameworkCore - EntityFrameworkCore.design - EntityFrameworkCore.sql
namespace SuperHeroAPI.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
