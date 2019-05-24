using EntityFrameworkConsole.Models;
using System.Collections.Generic;

namespace EntityFrameworkConsole.Data
{
    public static class BandDataLayer
    {
        public static List<Band> GetBands()
        {
            var bands = new List<Band>();
            bands.Add(new Band() { BandId = 1, Name = "Black Sabbath" });
            bands.Add(new Band() { BandId = 2, Name = "The Revolution" });
            bands.Add(new Band() { BandId = 3, Name = "Pink Floyd" });
            bands.Add(new Band() { BandId = 4, Name = "Eagles" });
            bands.Add(new Band() { BandId = 5, Name = "The Clash" });
            return bands;
        }

        public static List<Musician> GetMusicians()
        {
            var bands = GetBands();
            var musicians = new List<Musician>();
            musicians.Add(new Musician() { Name = "Ozzy Osbourne", Band = bands.Find(x => x.Name.Equals("Black Sabbath")) });
            musicians.Add(new Musician() { Name = "Prince", Band = bands.Find(x => x.Name.Equals("The Revolution")) });
            musicians.Add(new Musician() { Name = "Roger Waters", Band = bands.Find(x => x.Name.Equals("Pink Floyd")) });
            musicians.Add(new Musician() { Name = "Glenn Frey", Band = bands.Find(x => x.Name.Equals("Eagles")) });
            musicians.Add(new Musician() { Name = "Don Henley", Band = bands.Find(x => x.Name.Equals("Eagles")) });
            musicians.Add(new Musician() { Name = "Moby" });
            return musicians;
        }
    }
}
