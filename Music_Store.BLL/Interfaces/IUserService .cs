using Music_Store.BLL.DTO;
using Music_Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.BLL.Interfaces
{
    public interface IUserService
    {
        bool CheckLogin2(string Login);
        bool CheckEmail(string Mail);
    }
}
