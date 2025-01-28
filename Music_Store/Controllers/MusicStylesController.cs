using Microsoft.AspNetCore.Mvc;
using Music_Store.BLL.DTO;
using Music_Store.BLL.Interfaces;
using Music_Store.BLL.Services;
using Music_Store.Models;


namespace Music_Store.Controllers
{
    public class MusicStylesController : Controller
    {
        private readonly IRepositoryMiddle<MusicStyleDTO> styleService;
        public MusicStylesController(IRepositoryMiddle<MusicStyleDTO> styleService)
        {
            this.styleService = styleService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await styleService.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Style")] MusicStyle musicStyle)
        {
            if (ModelState.IsValid)
            {
                if (styleService.Check(musicStyle.Style))
                {
                    MusicStyleDTO musicStyleDTO = new() { Id = musicStyle.Id, Style = musicStyle.Style };
                    await styleService.Create(musicStyleDTO);

                    return PartialView("Success");

                }
                else
                {
                    ModelState.AddModelError("Name", "Такой стль уже есть");
                    return PartialView("Create");
                }
            }
            return PartialView("Create");
        }
        public IActionResult CheckStyle(string Style)
        {
            return Json(styleService.Check(Style));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var musicStyle = await styleService.Get(id);
            if (musicStyle == null)
            {
                return NotFound();
            }
            return PartialView("Edit", musicStyle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MusicStyleDTO musicStyle)
        {
            if (ModelState.IsValid)
            {
                await styleService.Update(musicStyle);
                //return PartialView("Success2");
                return RedirectToAction(nameof(Index));
            }
            return PartialView("Edit", musicStyle);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var musicStyle = await styleService.Get(id);
            if (musicStyle == null)
            {
                return NotFound();
            }
            return PartialView("Delete", musicStyle);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await styleService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
