using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Music_Store.Models
{
    public class Singer
    {
        public int Id { get; set; }
        [Display(Name = "Имя исполнителя")]
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Remote(action: "CheckName", controller: "Singers", ErrorMessage = "Этот исполнитель уже есть")]
        public string? Name { get; set; }
    }
}
