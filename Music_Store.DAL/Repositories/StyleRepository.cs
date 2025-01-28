using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.EF;
using Music_Store.DAL.Entities;
using Music_Store.DAL.Interfaces;


namespace Music_Store.DAL.Repositories
{
    public class StyleRepository : IRepository<MusicStyles>
    {
        private readonly MSContext _context;
        public StyleRepository(MSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MusicStyles>> GetAll()
        {
            return await _context.MusicStyles.ToListAsync();
        }
        public async Task<MusicStyles> Get(int id)
        {
            return await _context.MusicStyles.FindAsync(id);
        }
        public async Task<MusicStyles> Get(string name)  
        {
            var styles = await _context.MusicStyles.Where(a => a.Style == name).ToListAsync();
            MusicStyles? style = styles?.FirstOrDefault();
            return style;
        }
        public async Task Create(MusicStyles item)
        {
            await _context.MusicStyles.AddAsync(item);
        }
        public async Task Update(MusicStyles item)
        {
            _context.MusicStyles.Update(item);
        }
        public async Task Delete(int id)
        {
            MusicStyles? item = await _context.MusicStyles.FindAsync(id);
                if (item != null)
                _context.MusicStyles.Remove(item);
        }
        public bool Check(string Style)
        {
            if ((_context.MusicStyles?.Any(e => e.Style == Style)).GetValueOrDefault())
                return true;
            return false;
        }
    }
}
