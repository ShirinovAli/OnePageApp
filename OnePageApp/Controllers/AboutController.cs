using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnePageApp.DataAccess;
using OnePageApp.Dtos.AboutDtos;
using OnePageApp.Entities;

namespace OnePageApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly ApplicationContext _context;
        public AboutController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AboutListDto> abouts = await _context
                    .Abouts
                    .Select(x => new AboutListDto()
                    {
                        AboutId = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        ButtonText = x.ButtonText
                    })
                    .OrderByDescending(x => x.AboutId)
                    .ToListAsync();

            return View(abouts);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);


            About about = new()
            {
                Title = dto.Title,
                Description = dto.Description,
                ButtonText = dto.ButtonText
            };

            await _context.Abouts.AddAsync(about);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "About");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var updatedData = await _context.Abouts.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (updatedData == null)
                return RedirectToAction("Error", "Home");

            EditAboutDto dto = new()
            {
                AboutId = updatedData.Id,
                Title = updatedData.Title,
                Description = updatedData.Description,
                ButtonText = updatedData.ButtonText
            };

            return View(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditAboutDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            About updatedData = await _context.Abouts.Where(x => x.Id == dto.AboutId).FirstOrDefaultAsync();

            if (updatedData == null)
                return RedirectToAction("Error", "Home");


            updatedData.Title = dto.Title;
            updatedData.Description = dto.Description;
            updatedData.ButtonText = dto.ButtonText;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Error", "Home");


            var deletedData = await _context.Abouts.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (deletedData == null)
                return RedirectToAction("Error", "Home");

            _context.Abouts.Remove(deletedData);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
