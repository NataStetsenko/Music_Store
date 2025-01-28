using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DAL.Entities
{
    public class Singers
    {
        public Singers()
        {
            Music_sr = new HashSet<Musics>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Musics>? Music_sr { get; set; }
    }
}
