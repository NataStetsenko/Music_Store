using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.BLL.Interfaces
{
    public interface ISoltServic
    {
        string Solt();
        string Pass(string pass, string salt);
        bool PasswordCheck(string pass, string pass1, string salt1);
    }
}
