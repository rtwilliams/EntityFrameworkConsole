using EntityFrameworkConsole.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkConsole.Repositories
{
    public class BandRepository : GenericRepository<Band>
    {
        public BandRepository(DB_Bands entityContext) : base(entityContext) { }

        public override List<Band> GetAll()
        {
            return Table.Include(x => x.Musicians).ToList();
        }
    }
}
