
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkConsole.Interfaces;
using System.Data.Entity;

namespace EntityFrameworkConsole.Repositories
{
    public class BandRepository : IBandRepository
    {
        private EntityDbContext EntityContext { get; set; }

        public BandRepository(EntityDbContext entityContext)
        {
            EntityContext = entityContext;
        }

        public IEnumerable<Band> GetAllBands()
        {
            return EntityContext.Bands.Include(b => b.Musicians).ToList();
        }

        public Band GetBandById(int id)
        {
            return GetAllBands().FirstOrDefault(i => i.BandId == id);
        }

        public void Add(Band band)
        {
            EntityContext.Bands.Add(band);
        }

        public void Edit(Band band)
        {
            var bandEntity = GetBandById(band.BandId);
            if (bandEntity == null) return;
            bandEntity.Name = band.Name;
            bandEntity.Musicians = band.Musicians;
        }

        public void Delete(Band band)
        {
            EntityContext.Bands.Remove(band);
        }

        public void Save()
        {
            EntityContext.SaveChanges();
        }
    }
}
