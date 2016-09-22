using System;
using EntityFrameworkConsole;
using EntityFrameworkConsole.Repositories;

namespace EntityFrameworkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //SeedDatabase();
            PrintBandsAndMucisians();
            Console.WriteLine("");
            PrintMusicians();
        }

        static void PrintBandsAndMucisians()
        {
            Console.WriteLine("Bands and Mucisians Are...");
            using (var db = new EntityDbContext())
            {
                var bandRespos = new BandRepository(db);
                foreach (var band in bandRespos.GetAllBands())
                {
                    Console.WriteLine("Band: " + band.Name);
                    Console.WriteLine("     Mambers:");
                    foreach (var member in band.Musicians)
                    {
                        Console.WriteLine("          Name: " + member.Name);
                    }
                }
            }
        }

        static void PrintMusicians()
        {
            Console.WriteLine("Mucisians Are...");
            using (var db = new EntityDbContext())
            {
                var musicianRepos = new MusicianRepository(db);
                foreach (var musician in musicianRepos.GetAllMusicians())
                {
                    if (musician.Band != null)
                        Console.WriteLine("Name: " + musician.Name + " - Band: " + musician.Band.Name);
                    else
                        Console.WriteLine("Name: " + musician.Name);
                }
            }
        }

        static void SeedDatabase()
        {
            var blackSabbath = new Band() { Name = "Black Sabbath" };
            var revolution = new Band() { Name = "The Revolution" };

            var ozzy = new Musician() {Name = "Ozzy Osbourne", Band = blackSabbath};
            var prince = new Musician() {Name = "Prince", Band = revolution};
            var moby = new Musician() {Name = "Moby"};

            using (var db = new EntityDbContext())
            {
                var bandRepos = new BandRepository(db);
                bandRepos.Add(blackSabbath);
                bandRepos.Add(revolution);
                bandRepos.Save();
                Console.WriteLine("Bands Added!");

                var musicianRepos = new MusicianRepository(db);
                musicianRepos.Add(ozzy);
                musicianRepos.Add(prince);
                musicianRepos.Add(moby);
                musicianRepos.Save();
                Console.WriteLine("Musicians Added!");
            }
        }
    }
}
