using Music_Store.DAL.Entities;


namespace Music_Store.DAL.Interfaces
{
    public interface IRepositoryForUsers
    {
        bool CheckEmail(string Mail);
    }
}
