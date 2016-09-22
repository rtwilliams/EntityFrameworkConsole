
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkConsole.Interfaces;
using System.Data.Entity;

namespace EntityFrameworkConsole.Repositories
{
    public class MusicianRepository : IMusicianRepository
    {
        private EntityDbContext EntityContext { get; set; }

        public MusicianRepository(EntityDbContext entityContext)
        {
            EntityContext = entityContext;
        }

        public IEnumerable<Musician> GetAllMusicians()
        {
            return EntityContext.Musicians.Include(x => x.Band).ToList();
        }

        public Musician GetMusicianById(int id)
        {
            return GetAllMusicians().FirstOrDefault(i => i.MusicianId == id);
        }

        public void Add(Musician musician)
        {
            EntityContext.Musicians.Add(musician);
        }

        public void Edit(Musician musician)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Musician musician)
        {
            EntityContext.Musicians.Remove(musician);
        }

        public void Save()
        {
            EntityContext.SaveChanges();
        }
    }
}
