using Microsoft.AspNetCore.Mvc.Rendering;
using Music_Store.BLL.DTO;
using Music_Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.BLL.Interfaces
{
    public interface IMusicService
    {
        SelectList Get(string arg, string arg2);
        SelectList Get2(string arg, string arg2);
        SelectList Get(string arg, string arg2, MusicDTO arg3);
        SelectList Get2(string arg, string arg2, MusicDTO arg3);
    }
}
