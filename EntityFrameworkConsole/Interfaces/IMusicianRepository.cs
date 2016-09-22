
using System.Collections.Generic;

namespace EntityFrameworkConsole.Interfaces
{
    public interface IMusicianRepository
    {
        IEnumerable<Musician> GetAllMusicians();
        Musician GetMusicianById(int id);
        void Add(Musician musician);
        void Edit(Musician musician);
        void Delete(Musician musician);
        void Save();
    }
}
