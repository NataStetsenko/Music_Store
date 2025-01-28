using Music_Store.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.BLL.Interfaces
{
    public interface IRepositoryMiddle<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task<T> Get(int id);
        Task<T> Get(string name);
        bool Check(string Style);
    }
}
