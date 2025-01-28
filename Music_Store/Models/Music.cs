using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Music_Store.Models
{
    public class MusicView
    {
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Remote(action: "CheckName", controller: "Musics", ErrorMessage = "Такая песня уже есть")]
        [Display(Name = "Название")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Display(Name = "Альбом")]
        public string? Album { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Display(Name = "Год выпуска")]
        [Range(1900, 2023, ErrorMessage = "Недопустимый год")]
        public string? Year { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Display(Name = "Стиль")]
        public string? MusicStyle { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Display(Name = "Исполнитель")]
        public string? Singer { get; set; }
    }
    public class MusicViewEdit
    {
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Display(Name = "Название")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Display(Name = "Альбом")]
        public string? Album { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Display(Name = "Год выпуска")]
        [Range(1900, 2023, ErrorMessage = "Недопустимый год")]
        public string? Year { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Display(Name = "Стиль")]
        public string? MusicStyle { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить")]
        [Display(Name = "Исполнитель")]
        public string? Singer { get; set; }
    }
}
