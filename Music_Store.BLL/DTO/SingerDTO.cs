using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Music_Store.BLL.DTO
{
    public class SingerDTO
    {
        public int Id { get; set; }
        [Display(Name = "Имя исполнителя")]
        public string? Name { get; set; }
    }
}
