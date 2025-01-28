using Microsoft.AspNetCore.Mvc;
using Music_Store.BLL.DTO;
using Music_Store.BLL.Interfaces;
using Music_Store.DAL.Entities;
using Music_Store.Models;


namespace Music_Store.Controllers
{
    public class MusicsController : Controller
    {
        private readonly IWebHostEnvironment appEnvironment;//информацию об окружении для видоса
        private readonly IMusicService musicService;
        private readonly IRepositoryMiddle<MusicDTO> repositoryMiddle;
        public MusicsController(IWebHostEnvironment appEnvironment, IMusicService musicService, IRepositoryMiddle<MusicDTO> repositoryMiddle)
        {
            this.appEnvironment = appEnvironment;
            this.musicService = musicService;
            this.repositoryMiddle = repositoryMiddle;
        }
        public IActionResult CheckName(string Name)
        {
            return Json(repositoryMiddle.Check(Name));
        }
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.Clear();
            return View(await repositoryMiddle.GetAll());
        }
        public async Task<IActionResult> Index2()
        {
            return View(await repositoryMiddle.GetAll());
        }
        public IActionResult Create()
        {
            ViewData["MusicStyle"] = musicService.Get("Style", "Style");
            ViewData["Singer"] = musicService.Get2("Name", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Album,Year, MusicStyle, Singer")] MusicView music, IFormFile uploadedFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var filePath = "~/Image/" + uploadedFile.FileName;
                    var filePathFolder = "/Image/" + uploadedFile.FileName;
                    using var fileStream = new FileStream(appEnvironment.WebRootPath + filePathFolder, FileMode.Create);
                    await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                    FileModel file = new() { Name = uploadedFile.FileName, Path = filePathFolder };
                    var log = HttpContext.Session.GetString("login");
                    MusicDTO musicDTO = new()
                    {
                        Name = music.Name,
                        Album = music.Album,
                        Year = music.Year,
                        MusicStyle = music.MusicStyle,
                        Singer = music.Singer,
                        VideoDate = DateTime.Now,
                        Video = filePath,
                        User = log
                    };
                    await repositoryMiddle.Create(musicDTO);
                    return RedirectToAction(nameof(Index2));
                }
            }
            catch { }
            ViewData["MusicStyle"] = musicService.Get("Style", "Style");
            ViewData["Singer"] = musicService.Get2("Name", "Name");
            return View(music);
        }
        public async Task<IActionResult> Edit(int id)
        {
            MusicDTO music = await repositoryMiddle.Get(id);
            if (music == null)
            {
                return NotFound();
            }
            ViewData["MusicStyle"] = musicService.Get("Style", "Style", music);
            ViewData["Singer"] = musicService.Get2("Name", "Name", music);
            MusicViewEdit musicView = new()
            {
                Name = music.Name,
                Album = music.Album,
                Year = music.Year
            };
            return PartialView("Edit", musicView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Album,Year,MusicStyle,Singer")] MusicView musicView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MusicDTO item = new()
                    {
                        Id = id,
                        Name = musicView.Name,
                        Album = musicView.Album,
                        Year = musicView.Year,
                        MusicStyle = musicView.MusicStyle,
                        Singer = musicView.Singer
                    };
                    await repositoryMiddle.Update(item);
                    return RedirectToAction(nameof(Index2));
                }
                catch { }
            }
            MusicDTO music = await repositoryMiddle.Get(id);
            ViewData["MusicStyle"] = musicService.Get("Style", "Style", music);
            ViewData["Singer"] = musicService.Get2("Name", "Name", music);
            return PartialView("Edit", musicView);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var music = await repositoryMiddle.Get(id);
            if (music == null)
            {
                return NotFound();
            }
            return PartialView("Delete", music);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repositoryMiddle.Delete(id);
            return RedirectToAction(nameof(Index2));
        }
    }
}
