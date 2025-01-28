
namespace Music_Store.DAL.Entities
{
    public class MusicStyles 
    {
        public MusicStyles()
        {
            this.Music_ms = new HashSet<Musics>();
        }
        public int Id { get; set; }
        public string? Style { get; set; }
        public ICollection<Musics>? Music_ms { get; set; }
    }
}
