using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Music_Store.Models
{
    public class MusicStyle
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Remote(action: "CheckStyle", controller: "MusicStyles", ErrorMessage = "Этот стиль уже есть")]
        public string? Style { get; set; }
    }
}
