using AutoMapper;
using Music_Store.BLL.DTO;
using Music_Store.BLL.Interfaces;
using Music_Store.DAL.Entities;
using Music_Store.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace Music_Store.BLL.Services
{
    public class StyleService: IRepositoryMiddle<MusicStyleDTO>
    {
        IUnitOfWork Database { get; set; }
        public StyleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<MusicStyleDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MusicStyles, MusicStyleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<MusicStyles>, IEnumerable<MusicStyleDTO>>(await Database.Styles.GetAll());
        }
        public async Task Create(MusicStyleDTO item)
        {
            var musicStyle = new MusicStyles
            {
               Style = item.Style,
            };

            await Database.Styles.Create(musicStyle);
            await Database.Save();
        }
        public async Task Update(MusicStyleDTO item)
        {
            var musicStyle = new MusicStyles
            {
                Id = item.Id,
                Style = item.Style,
            };
            await Database.Styles.Update(musicStyle);
            await Database.Save();
        }
        public async Task Delete(int id)
        {
            await Database.Styles.Delete(id);
            await Database.Save();
        }
        public async Task<MusicStyleDTO> Get(string name)
        {
            var musicStyle = await Database.Styles.Get(name);
            if (musicStyle == null)
                throw new ValidationException("Wrong Style!");
            MusicStyleDTO musicStyleDTO = new()
            {
                Id = musicStyle.Id,
                Style = musicStyle.Style
            };
            return musicStyleDTO;
        }
        public async Task<MusicStyleDTO> Get(int id)
        {
            var musicStyle = await Database.Styles.Get(id);
            if (musicStyle == null)
                throw new ValidationException("Wrong Style!");
            return new MusicStyleDTO
            {
                Id = musicStyle.Id,
                Style = musicStyle.Style,
            };
        }
        public bool Check(string Style)
        {
            if (Database.Styles.Check(Style))
                return false;
            return true;
        }
    }
}
