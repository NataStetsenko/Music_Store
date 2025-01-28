using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.EF;
using Music_Store.DAL.Entities;
using Music_Store.DAL.Interfaces;


namespace Music_Store.DAL.Repositories
{
    public class UserRepository : IRepository<Users>, IRepositoryForUsers
    {
        private readonly MSContext _context;
        public UserRepository(MSContext context)
        {
            _context = context;
        }
        public async Task<Users> Get(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.Login == name);
        }
        public async Task Create(Users c)
        {
            await _context.Users.AddAsync(c);
        }
        public async Task<Users> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task Delete(int id)
        {
            Users? user = await _context.Users.FindAsync(id);
            if (user != null)
                _context.Users.Remove(user);
        }
        public async Task Update(Users item)
        {
            _context.Users.Update(item);
        }
        public bool Check(string Login)
        {
            if ((_context.Users?.Any(e => e.Login == Login)).GetValueOrDefault())
                return true;
            return false;
        }
        public bool CheckEmail(string Mail)
        {
            if ((_context.Users?.Any(e => e.Mail == Mail)).GetValueOrDefault())
                return true;
            return false;
        }
    }
}
