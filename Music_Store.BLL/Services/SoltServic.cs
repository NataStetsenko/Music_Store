using Music_Store.BLL.Interfaces;
using System.Security.Cryptography;
using System.Text;


namespace Music_Store.BLL.Services
{
    public class SoltServic: ISoltServic
    {
        public string Solt()
        {
            byte[] saltbuf = new byte[16];
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(saltbuf);

            StringBuilder sb = new(16);
            for (int i = 0; i < 16; i++)
                sb.Append(string.Format("{0:X2}", saltbuf[i]));
            return sb.ToString();
        }
        public string Pass(string pass, string salt)
        {
            //переводим пароль в байт-массив  
            byte[] password = Encoding.Unicode.GetBytes(salt + pass);

            //создаем объект для получения средств шифрования  
            var md5 = MD5.Create();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = md5.ComputeHash(password);

            StringBuilder hash = new(byteHash.Length);
            for (int i = 0; i < byteHash.Length; i++)
                hash.Append(string.Format("{0:X2}", byteHash[i]));
            return hash.ToString();
        }
        public bool PasswordCheck(string pass, string pass1, string salt1)
        {

            //переводим пароль в байт-массив  
            byte[] password = Encoding.Unicode.GetBytes(salt1 + pass);

            //создаем объект для получения средств шифрования  
            var md5 = MD5.Create();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = md5.ComputeHash(password);

            StringBuilder hash = new StringBuilder(byteHash.Length);
            for (int i = 0; i < byteHash.Length; i++)
                hash.Append(string.Format("{0:X2}", byteHash[i]));
            if (pass1 == hash.ToString())
                return true;
            return false;
        }
    }
}
