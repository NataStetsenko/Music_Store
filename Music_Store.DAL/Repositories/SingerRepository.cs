using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.EF;
using Music_Store.DAL.Entities;
using Music_Store.DAL.Interfaces;


namespace Music_Store.DAL.Repositories
{
    public class SingerRepository : IRepository<Singers>
    {
        private readonly MSContext _context;
        public SingerRepository(MSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Singers>> GetAll()
        {
            return await _context.Singers.ToListAsync();
        }
        public async Task<Singers> Get(int id)
        {
            return await _context.Singers.FindAsync(id);
        }
        public async Task<Singers> Get(string name)
        {
            var singers = await _context.Singers.Where(a => a.Name == name).ToListAsync();
            Singers? singer = singers?.FirstOrDefault();
            return singer;
        }
        public async Task Create(Singers item)
        {
            await _context.Singers.AddAsync(item);
        }
        public async Task Update(Singers item)
        {
            _context.Singers.Update(item);
        }
        public async Task Delete(int id)
        {
            Singers? item = await _context.Singers.FindAsync(id);
            if (item != null)
                _context.Singers.Remove(item);
        }
        public bool Check(string Name)
        {
            if ((_context.Singers?.Any(e => e.Name == Name)).GetValueOrDefault())
                return true;
            return false;
        }
    }
}
