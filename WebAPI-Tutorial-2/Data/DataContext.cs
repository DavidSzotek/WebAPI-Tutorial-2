using Microsoft.EntityFrameworkCore;
using WebAPI_Tutorial_2.Models;

namespace WebAPI_Tutorial_2.Data
{
    // DbContext contextualizes models to a database tables
    // 
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        // Name of the DB table, ususally just pluralised model name
        public DbSet<SuperHero> SuperHeroes{ get; set; }
    }
}
