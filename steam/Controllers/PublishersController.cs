using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using steam.Data;
using steam.Data.Services;
using steam.Models;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublishersService _service;

        public PublishersController(IPublishersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // Get : Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("StudioName,ProfilePictureURL,Bio")]Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }
            await _service.AddAsync(publisher);
            return RedirectToAction(nameof(Index));

        }

        // Get : Publishers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        // Get : Publishers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,StudioName,ProfilePictureURL,Bio")] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }
            await _service.UpdateAsync(id,publisher);
            return RedirectToAction(nameof(Index));

        }

        // Get : Publishers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
         
            return RedirectToAction(nameof(Index));

        }
    }
}
