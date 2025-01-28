using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Music_Store.BLL.DTO
{
    public class MusicDTO
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string? Name { get; set; }
        [Display(Name = "Альбом")]
        public string? Album { get; set; }
        [Display(Name = "Год выпуска")]
        public string? Year { get; set; }
        public string? Video { get; set; }
        [Display(Name = "Дата публикации")]
        public DateTime VideoDate { get; set; }
        public int UserId { get; set; } 
        public int MusicStyleId { get; set; }
        public int SingerId { get; set; }
        public string? User { get; set; }
        public string? MusicStyle { get; set; }
        public string? Singer { get; set; }
    }
}
