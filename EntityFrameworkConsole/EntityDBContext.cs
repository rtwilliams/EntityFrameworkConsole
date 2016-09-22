
using System.Data.Entity;

namespace EntityFrameworkConsole
{
    public class EntityDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Band> Bands { get; set; }
    }
}
