using AutoMapper;
using Music_Store.BLL.DTO;
using Music_Store.BLL.Interfaces;
using Music_Store.DAL.Entities;
using Music_Store.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace Music_Store.BLL.Services
{
    public class SingerService : IRepositoryMiddle<SingerDTO>
    {
        IUnitOfWork Database { get; set; }
        public SingerService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<SingerDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Singers, SingerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Singers>, IEnumerable<SingerDTO>>(await Database.Singers.GetAll());
        }
        public async Task Create(SingerDTO item)
        {
            var singer = new Singers
            {
                Name = item.Name,
            };

            await Database.Singers.Create(singer);
            await Database.Save();
        }
        public async Task Update(SingerDTO item)
        {
            var singer = new Singers
            {
                Id = item.Id,
                Name = item.Name,
            };
            await Database.Singers.Update(singer);
            await Database.Save();
        }
        public async Task Delete(int id)
        {
            await Database.Singers.Delete(id);
            await Database.Save();
        }
        public async Task<SingerDTO> Get(string name)
        {
            var singer = await Database.Singers.Get(name);
            if (singer == null)
                throw new ValidationException("Wrong singer!");
            return new SingerDTO
            {
                Id = singer.Id,
                Name = singer.Name,
            };
        }
        public async Task<SingerDTO> Get(int id)
        {
            var singer = await Database.Singers.Get(id);
            if (singer == null)
                throw new ValidationException("Wrong singer!");
            return new SingerDTO
            {
                Id = singer.Id,
                Name = singer.Name,
            };
        }
        public bool Check(string Name)
        {
            if (Database.Singers.Check(Name))
                return false;
            return true;
        }
  
    }
}
