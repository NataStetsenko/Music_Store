using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Music_Store.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string? Name { get; set; }
        [Display(Name = "Фамилия")]
        public string? Surname { get; set; }
        [Display(Name = "Логин")]
        public string? Login { get; set; }
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
        public string? PassSalt { get; set; }
        [Display(Name = "Адрес")]
        public string? Mail { get; set; }
        [Display(Name = "Уровень доступа")]
        public int UserLevel { get; set; }
    }
}
