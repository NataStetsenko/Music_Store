using Music_Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryForMusics Musics2 { get; }
        IRepositoryForUsers Users2 { get; }
        IRepository<Users> Users { get; }
        IRepository<Musics> Musics { get; }
        IRepository<MusicStyles> Styles { get; }
        IRepository<Singers> Singers { get; }
        Task Save();
    }
}
