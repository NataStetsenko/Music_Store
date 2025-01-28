using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.EF;
using Music_Store.DAL.Entities;
using Music_Store.DAL.Interfaces;
namespace Music_Store.DAL.Repositories
{
    public class MusicRepository : IRepository<Musics>, IRepositoryForMusics
    {
        private readonly MSContext _context;
        public MusicRepository(MSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Musics>> GetAll()
        {
            var musicContext = _context.Musics.Include(m => m.MusicStyle).Include(m => m.Singer).Include(m => m.User);
            return await musicContext.ToListAsync();
        }
        public SelectList Get(string arg, string arg2)
        {
            return new SelectList(_context.MusicStyles, arg, arg2);
        }
        public SelectList Get2(string arg, string arg2)
        {
            return new SelectList(_context.Singers, arg, arg2);
        }
        public SelectList Get(string arg, string arg2, Musics arg3)
        {
            return new SelectList(_context.MusicStyles, arg, arg2, arg3);
        }
        public SelectList Get2(string arg, string arg2, Musics arg3)
        {
            return new SelectList(_context.Singers, arg, arg2, arg3);
        }
        public async Task Create(Musics musics)
        {
            await _context.Musics.AddAsync(musics);
        }
        public bool Check(string Name)
        {
            if ((_context.Musics?.Any(e => e.Name == Name)).GetValueOrDefault())
                return false;
            return true;
        }
        public async Task<Musics> Get(int id)
        {
            return await _context.Musics.FindAsync(id);
        }
        public async Task<Musics> Get(string name)
        {
            return await _context.Musics.FirstOrDefaultAsync(m => m.Name == name);
        }
        public async Task Update(Musics music)
        {
            var temp = await _context.Musics.FirstOrDefaultAsync(m => m.Id == music.Id);
            if (temp != null)
            {
                temp.Name = music.Name;
                temp.Album = music.Album;
                temp.Year = music.Year;
                temp.SingerId = music.SingerId;
                temp.MusicStyleId = music.MusicStyleId;
                _context.Musics.Update(temp);
            }
        }
        public async Task Delete(int id)
        {
            Musics? item = await _context.Musics.FindAsync(id);
            if (item != null)
                _context.Musics.Remove(item);
        }
    }
}

