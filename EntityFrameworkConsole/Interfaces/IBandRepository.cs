
using System.Collections.Generic;

namespace EntityFrameworkConsole.Interfaces
{
    public interface IBandRepository
    {
        List<Band> GetAllBands();
        Band GetBandById(int id);
        void Add(Band band);
        void Edit(Band band);
        void Delete(Band band);
        void Save();
    }
}
