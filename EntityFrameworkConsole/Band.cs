
using System.Collections.Generic;

namespace EntityFrameworkConsole
{
    public class Band
    {
        public int BandId { get; set; }
        public string Name { get; set; }

        public List<Musician> Musicians { get; set; }
    }   
}
