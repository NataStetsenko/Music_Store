
namespace Music_Store.DAL.Entities
{
    public class Musics
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Album { get; set; }
        public string? Year { get; set; }
        public string? Video { get; set; }
        public DateTime VideoDate { get; set; }
        public MusicStyles? MusicStyle { get; set; }
        public Users? User { get; set; }
        public Singers? Singer { get; set; }
        public int MusicStyleId { get; set; }
        public int UserId { get; set; }
        public int SingerId { get; set; }

    }
}
