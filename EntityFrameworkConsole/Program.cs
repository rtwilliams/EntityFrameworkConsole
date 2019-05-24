using System;
using System.Linq;
using EntityFrameworkConsole.Data;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Repositories;

namespace EntityFrameworkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //SeedDatabase();
            ReseedDatabase();
            PrintBands();
            PrintMusicians();
            PrintBandsWithMusicians();
            EditMusician();
            DeleteMusician();
            PrintBandsWithMusicians();
        }

        static void PrintBands()
        {
            Console.WriteLine("Bands are ...");
            using (var db = new DB_Bands())
            {
                var repo = new BandRepository(db);
                foreach (var band in repo.GetAll())
                {
                    Console.WriteLine("Name: " + band.Name);
                }
            }
            Console.WriteLine("");
        }

        static void PrintMusicians()
        {
            Console.WriteLine("Mucisians Are...");
            using (var db = new DB_Bands())
            {
                var repo = new MusicianRepository(db);
                foreach (var musician in repo.GetAll())
                {
                    Console.WriteLine("Name: " + musician.Name);
                }
            }
            Console.WriteLine("");
        }

        static void PrintBandsWithMusicians()
        {
            Console.WriteLine("Bands with Musicians Are...");
            using (var db = new DB_Bands())
            {
                var repo = new BandRepository(db);
                foreach (var band in repo.GetAll())
                {
                    if (band.Musicians.Count == 0)
                        continue;

                    Console.WriteLine(band.Name);
                    Console.WriteLine("     Members:");
                    foreach (var member in band.Musicians)
                    {
                        Console.WriteLine("          " + member.Name);
                    }
                }
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Edits a musician; this is not the most efficient way to edit a record; just demonstrating the repository in action.
        /// </summary>
        static void EditMusician()
        {
            using (var db = new DB_Bands())
            {
                var musicianRepo = new MusicianRepository(db);
                var bandRepo = new BandRepository(db);
                var random = new Random();
                var bands = bandRepo.GetAll();
                var musicians = musicianRepo.GetAll();
                var mi = random.Next(0, musicians.Count);
                var bi = random.Next(0, bands.Count);

                var musicianId = musicians[mi].MusicianId;
                var bandId = bands[bi].BandId;
                var randomMusician = musicianRepo.GetById(musicianId);
                var randomBand = bandRepo.GetById(bandId);

                if (randomMusician.Band != null && randomMusician.Band.Name.Equals(randomBand.Name))
                {
                    Console.WriteLine("Selected " + randomMusician.Name + " and " + randomBand.Name + ". No Edit was made. Please try again.");
                    Console.WriteLine("");
                    return;
                }

                randomMusician.Band = randomBand;
                musicianRepo.Save();
                Console.WriteLine("Edited: " + randomMusician.Name + " - New band: " + randomMusician.Band.Name);
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Deleted a musician; this is not the most efficient way to edit a record; just demonstrating the repository in action.
        /// </summary>
        static void DeleteMusician()
        {
            using (var db = new DB_Bands())
            {
                var repo = new MusicianRepository(db);
                var random = new Random();
                var musicians = repo.GetAll();
                var index = random.Next(0, musicians.Count);
                var musicianId = musicians[index].MusicianId;
                var randomMusician = repo.GetById(musicianId);
                repo.Delete(randomMusician);
                repo.Save();
                Console.WriteLine("Deleted: " + randomMusician.Name);
            }
            Console.WriteLine("");
        }

        static void DeleteAllDatabaseRecords()
        {
            using (var db = new DB_Bands())
            {
                var musicianRepo = new MusicianRepository(db);
                var bandRepo = new BandRepository(db);
                var musicians = musicianRepo.GetAll();
                foreach (var musician in musicians)
                {
                    musicianRepo.Delete(musician);
                }
                musicianRepo.Save();
                var bands = bandRepo.GetAll();
                foreach (var band in bands)
                {
                    bandRepo.Delete(band);
                }
                bandRepo.Save();
            }
        }


        /// <summary>
        /// Deletes all records and adds seed data to database.
        /// </summary>
        static void ReseedDatabase()
        {
            Console.WriteLine("Attempting to RESEED the database...");
            try
            {
                DeleteAllDatabaseRecords();
                Console.WriteLine("Database has been cleared.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while trying to clear all records in the database: " + ex.Message);
            }
            SeedDatabase();
        }

        /// <summary>
        /// Add records for bands and musicians to database.
        /// </summary>
        static void SeedDatabase()
        {
            Console.WriteLine("Attempting to seed database...");
            try
            {
                // check if data exists
                using (var db = new DB_Bands())
                {
                    var repo = new MusicianRepository(db);
                    if (repo.GetAll().Count > 0)
                    {
                        Console.WriteLine("Data Exists! Retrieving data... ");
                        Console.WriteLine("");
                        return;
                    }
                }

                // Seeding database - make sure the App.config connection string is targeting a valid SQL Server instance.
                Console.WriteLine("Seeding database... ");

                using (var db = new DB_Bands())
                {
                    var musicians = BandDataLayer.GetMusicians();
                    var musicianRepo = new MusicianRepository(db);
                    foreach (var musician in musicians)
                    {
                        musicianRepo.Add(musician);
                    }
                    musicianRepo.Save();

                    // let's check if all data was stored
                    var seedBands = BandDataLayer.GetBands();
                    var bandRepo = new GenericRepository<Band>(db);
                    var dbbands = bandRepo.GetAll().Select(y => y.Name).ToList();
                    foreach (var band in seedBands)
                    {
                        if (!dbbands.Contains(band.Name))
                            bandRepo.Add(band);
                    }
                    bandRepo.Save();

                    Console.WriteLine("Data Stored to Database!");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while trying to seed the database: " + ex.Message);
            }
        }
    }
}
