using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Music_Store.BLL.DTO;
using Music_Store.BLL.Interfaces;
using Music_Store.DAL.Entities;
using Music_Store.DAL.Interfaces;



namespace Music_Store.BLL.Services
{
    public class MusicService : IRepositoryMiddle<MusicDTO>, IMusicService
    {
        IUnitOfWork Database { get; set; }
        public MusicService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<MusicDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Musics, MusicDTO>()
            .ForMember("User", opt => opt.MapFrom(c => c.User.Login))
            .ForMember("MusicStyle", opt => opt.MapFrom(c => c.MusicStyle.Style))
            .ForMember("Singer", opt => opt.MapFrom(c => c.Singer.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Musics>, IEnumerable<MusicDTO>>(await Database.Musics.GetAll());
        }
        public SelectList Get(string arg, string arg2)
        {
            return Database.Musics2.Get(arg, arg2);
        }
        public SelectList Get2(string arg, string arg2)
        {
            return Database.Musics2.Get2(arg, arg2);
        }
        public async Task Create(MusicDTO item)
        {
            var usr = await Database.Users.Get(item.User);
            var st = await Database.Styles.Get(item.MusicStyle);
            var sin = await Database.Singers.Get(item.Singer);
            Musics musics = new()
            {
                Name = item.Name,
                Album = item.Album,
                Year = item.Year,
                Video = item.Video,
                VideoDate = DateTime.Now,
                MusicStyleId = st.Id,
                UserId = usr.Id,
                SingerId = sin.Id
            };
            await Database.Musics.Create(musics);
            await Database.Save();
        }
        public bool Check(string Name)
        {
            if (Database.Musics.Check(Name))
                return true;
            return false;
        }
        public async Task<MusicDTO> Get(int id)
        {
            var temp = await Database.Musics.Get(id);
            var usr = await Database.Users.Get(temp.UserId);
            var st = await Database.Styles.Get(temp.MusicStyleId);
            var sin = await Database.Singers.Get(temp.SingerId);
            MusicDTO musicDTO = new()
            {
                Name = temp.Name,
                Album = temp.Album,
                Year = temp.Year,
                Video = temp.Video,
                VideoDate = temp.VideoDate,
                MusicStyleId = temp.Id,
                UserId = temp.Id,
                SingerId = temp.Id,
                MusicStyle = st.Style,
                Singer = sin.Name,
                User = usr.Login
            };
            return musicDTO;
        }
        public SelectList Get(string arg, string arg2, MusicDTO arg3)
        {
            Musics musics = new()
            {
                Id = arg3.Id,
                Name = arg3.Name,
                MusicStyleId = arg3.MusicStyleId
            };
            return Database.Musics2.Get(arg, arg2, musics);
        }
        public SelectList Get2(string arg, string arg2, MusicDTO arg3)
        {
            Musics musics = new()
            {
                Id = arg3.Id,
                Name = arg3.Name,
                SingerId = arg3.SingerId
            };
            return Database.Musics2.Get2(arg, arg2, musics);
        }
        public async Task Update(MusicDTO item)
        {
            var st = await Database.Styles.Get(item.MusicStyle);
            var sin = await Database.Singers.Get(item.Singer);
            Musics musics = new()
            {
                Id = item.Id,
                Name = item.Name,
                Year = item.Year,
                Album = item.Album,
                MusicStyleId = st.Id,
                SingerId = sin.Id
            };
            await Database.Musics.Update(musics);
            await Database.Save();
        }
        public async Task Delete(int id)
        {
            await Database.Musics.Delete(id);
            await Database.Save();
        }
        public async Task<MusicDTO> Get(string name)
        {
            var temp = await Database.Musics.Get(name);
            var usr = await Database.Users.Get(temp.UserId);
            var st = await Database.Styles.Get(temp.MusicStyleId);
            var sin = await Database.Singers.Get(temp.SingerId);
            MusicDTO musicDTO = new()
            {
                Name = temp.Name,
                Album = temp.Album,
                Year = temp.Year,
                Video = temp.Video,
                VideoDate = temp.VideoDate,
                MusicStyleId = temp.Id,
                UserId = temp.Id,
                SingerId = temp.Id,
                MusicStyle = st.Style,
                Singer = sin.Name,
                User = usr.Login
            };
            return musicDTO;
        }
    }
}
