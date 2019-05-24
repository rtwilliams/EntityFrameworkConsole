using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using EntityFrameworkConsole.Models;

namespace EntityFrameworkConsole.Repositories
{
    public class MusicianRepository : GenericRepository<Musician>
    {
        public MusicianRepository(DB_Bands entityContext) : base(entityContext) { }

        public override List<Musician> GetAll()
        {
            return Table.Include(x => x.Band).ToList();
        }
    }
}
