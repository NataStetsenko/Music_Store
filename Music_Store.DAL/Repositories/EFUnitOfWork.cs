using Music_Store.DAL.EF;
using Music_Store.DAL.Entities;
using Music_Store.DAL.Interfaces;


namespace Music_Store.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private MSContext db;
        private UserRepository userRepository;
        private UserRepository userRepository2;
        private MusicRepository musicRepository;
        private MusicRepository musicRepository2;
        private StyleRepository styleRepository;
        private SingerRepository singerRepository;

        public EFUnitOfWork(MSContext context)
        {
            db = context;
        }
        public  IRepositoryForUsers Users2
        {
            get
            {
                if (userRepository2 == null)
                    userRepository2 = new UserRepository(db);
                return userRepository2;
            }
        }
        public IRepositoryForMusics Musics2
        {
            get
            {
                if (musicRepository2 == null)
                    musicRepository2 = new MusicRepository(db);
                return musicRepository2;
            }
        }
        public IRepository<MusicStyles> Styles
        {
            get
            {
                if (styleRepository == null)
                    styleRepository = new StyleRepository(db);
                return styleRepository;
            }
        }
        public IRepository<Users> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IRepository<Musics> Musics
        {
            get
            {
                if (musicRepository == null)
                    musicRepository = new MusicRepository(db);
                return musicRepository;
            }
        }
        public IRepository<Singers> Singers
        {
            get
            {
                if (singerRepository == null)
                    singerRepository = new SingerRepository(db);
                return singerRepository;
            }
        }
        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
