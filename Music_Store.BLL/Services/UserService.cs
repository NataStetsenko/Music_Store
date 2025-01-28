
using Music_Store.BLL.Interfaces;
using Music_Store.BLL.DTO;
using Music_Store.DAL.Entities;
using Music_Store.DAL.Interfaces;
using Music_Store.BLL.Infrastructure;
using AutoMapper;

namespace Music_Store.BLL.Services
{
    public class UserService : IRepositoryMiddle<UserDTO>, IUserService
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, IEnumerable<UserDTO>>(await Database.Users.GetAll());
        }
        public async Task Create(UserDTO item)
        {
            ISoltServic soltServic = new SoltServic();
            var user = new Users
            {
                Name = item.Name,
                Surname = item.Surname,
                Login = item.Login,
                PassSalt = soltServic.Solt(),
                Mail = item.Mail,
                UserLevel = 0
            };
            user.Password = soltServic.Pass(item.Password, user.PassSalt);
            await Database.Users.Create(user);
            await Database.Save();
        }
        public bool Check(string Login)
        {
            if (Database.Users.Check(Login))
                return false;
            return true;
        }
        public bool CheckLogin2(string Login)
        {
            if (Database.Users.Check(Login))
                return true;
            return false;
        }
        public bool CheckEmail(string Mail)
        {
            if (Database.Users2.CheckEmail(Mail))
                return false;
            return true;
        }
        public async Task<UserDTO> Get(int id)
        {
            var user = await Database.Users.Get(id);
            if (user == null)
                throw new ValidationException("Wrong user!", "");
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                Password = user.Password,
                PassSalt = user.PassSalt,
                Mail = user.Mail,
                UserLevel = user.UserLevel
            };
        }
        public async Task Delete(int id)
        {
            await Database.Users.Delete(id);
            await Database.Save();
        }
        public async Task Update(UserDTO item)
        {
                var user = new Users
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Login = item.Login,
                    Password = item.Password,
                    PassSalt = item.PassSalt,
                    Mail = item.Mail,
                    UserLevel = item.UserLevel
                };
                await Database.Users.Update(user);
                await Database.Save();
        }
        public async Task<UserDTO> Get(string name)
        {
            var user = await Database.Users.Get(name);
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                Password = user.Password,
                PassSalt= user.PassSalt,
                Mail = user.Mail,
                UserLevel = user.UserLevel
            };
        }
    }
}
