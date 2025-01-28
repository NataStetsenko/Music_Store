using Microsoft.AspNetCore.Mvc.Rendering;
using Music_Store.DAL.Entities;

namespace Music_Store.DAL.Interfaces
{
    public interface IRepositoryForMusics
    {
        SelectList Get(string arg, string arg2);
        SelectList Get2(string arg, string arg2);
        SelectList Get(string arg, string arg2, Musics arg3);
        SelectList Get2(string arg, string arg2, Musics arg3);
    }
}
