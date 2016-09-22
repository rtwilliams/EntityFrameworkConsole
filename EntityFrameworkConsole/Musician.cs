
namespace EntityFrameworkConsole
{
    public class Musician
    {
        public int MusicianId { get; set; }
        public string Name { get; set; }

        public Band Band { get; set; }   
    }
}
