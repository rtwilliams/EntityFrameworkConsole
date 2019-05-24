using EntityFrameworkConsole.Models;
using System.Data.Entity;

namespace EntityFrameworkConsole
{
    public class DB_Bands : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Band> Bands { get; set; }
    }
}
