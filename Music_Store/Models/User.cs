using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Music_Store.Models
{
    public class UserCreate
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Необходимо заполнить")]
        public string? Name { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Необходимо заполнить")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Remote(action: "CheckLogin", controller: "Users", ErrorMessage = "Логин уже используется")]
        [Display(Name = "Логин")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить")]
        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Адрес")]
        [Remote(action: "CheckEmail", controller: "Users", ErrorMessage = "Адрес уже используется")]
        public string? Mail { get; set; }
    }
    public class UserSing
    {
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Remote(action: "CheckLogin2", controller: "Users", ErrorMessage = "Логин не зарегистрирован")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        public string? Password { get; set; }
    }
}
