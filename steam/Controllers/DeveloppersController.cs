using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using steam.Data;
using steam.Data.Services;
using steam.Models;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Controllers
{
    public class DeveloppersController : Controller
    {
        private readonly IDeveloppersService _service;

        public DeveloppersController(IDeveloppersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allDeveloppers = await _service.GetAllAsync();
            return View(allDeveloppers);
        }

        //GET : developpers/details/id
        public async Task<IActionResult> Details(int id)
        {
            var developpersDetails = await _service.GetByIdAsync(id);
            if(developpersDetails == null) return View("NotFound");
            return View(developpersDetails);
        }
        //GET : developpeurs/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,StudioName,Bio")]Developper developpeur)
        {
            if(!ModelState.IsValid)return View(developpeur);

            await _service.AddAsync(developpeur);
            return RedirectToAction(nameof(Index));
        }

        //GET : developpeurs/edit/1
        public async  Task<IActionResult> Edit(int id)
        {
            var developperDetails = await _service.GetByIdAsync(id);
            if (developperDetails == null) return View("NotFound");
            return View(developperDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL,StudioName,Bio")] Developper developpeur)
        {
            if (!ModelState.IsValid) return View(developpeur);

            if(id == developpeur.Id)
            {
                await _service.UpdateAsync(id, developpeur);
                return RedirectToAction(nameof(Index));
            }

            return View(developpeur);
            
        }

        //GET : developpeurs/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var developperDetails = await _service.GetByIdAsync(id);
            if (developperDetails == null) return View("NotFound");
            return View(developperDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var developperDetails = await _service.GetByIdAsync(id);
            if (developperDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
