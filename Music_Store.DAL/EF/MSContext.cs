using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Store.DAL.Entities;

namespace Music_Store.DAL.EF
{
    public class MSContext : DbContext
    {
        public MSContext(DbContextOptions<MSContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<MusicStyles> MusicStyles { get; set; }
        public DbSet<Singers> Singers { get; set; }
        public DbSet<Musics> Musics { get; set; }
    }
}
