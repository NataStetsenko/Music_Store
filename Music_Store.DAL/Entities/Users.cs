using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DAL.Entities
{
    public class Users
    {
        public Users()
        {
            this.Music_u = new HashSet<Musics>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? PassSalt { get; set; }
        public string? Mail { get; set; }
        public int UserLevel { get; set; }
        public ICollection<Musics>? Music_u { get; set; }
    }
}
