using Microsoft.AspNetCore.Mvc;
using Music_Store.BLL.DTO;
using Music_Store.BLL.Interfaces;
using Music_Store.BLL.Services;
using Music_Store.Models;


namespace Music_Store.Controllers
{
    public class SingersController : Controller
    {
        private readonly IRepositoryMiddle<SingerDTO> singerService;
        public SingersController(IRepositoryMiddle<SingerDTO> singerService)
        {
            this.singerService = singerService;
        }
        public async Task<IActionResult> Index()
        {
            var temp = await singerService.GetAll();
            return View(temp);
        }
        public IActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Singer singer)
        {
            if (ModelState.IsValid)
            {
                if (singerService.Check(singer.Name))
                {
                    SingerDTO singerDTO = new() { Id = singer.Id, Name = singer.Name };
                    await singerService.Create(singerDTO);
                    return PartialView("Success");

                }
                else
                {
                    ModelState.AddModelError("Name", "Такой исполнитель уже есть");
                    return PartialView("Create");
                }

            }
            return PartialView("Create");
        }
        public IActionResult CheckName(string Name)
        {
            return Json(singerService.Check(Name));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var singer = await singerService.Get(id);
            if (singer == null)
            {
                return NotFound();
            }

            return PartialView("Edit", singer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SingerDTO singer)
        {
            if (ModelState.IsValid)
            {
                await singerService.Update(singer);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("Edit", singer);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var singer = await singerService.Get(id);
            if (singer == null)
            {
                return NotFound();
            }
            return PartialView("Delete", singer);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await singerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
