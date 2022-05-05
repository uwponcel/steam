using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using steam.Data;
using steam.Data.Services;
using steam.Models;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _service;

        public GamesController(IGamesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allGames = await _service.GetAllAsync();
            return View(allGames);
        }

        //GET : Games/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var gameDetails = await _service.GetGameByIdAsync(id);
            return View(gameDetails);
        }

        //GET : Games/Create
        public async Task<IActionResult> Create()
        {

            var movieDropdownData = await _service.GetNewGameDropdownsValues();

            ViewBag.Developpers = new SelectList(movieDropdownData.Developpers, "Id", "StudioName");
            ViewBag.Publishers = new SelectList(movieDropdownData.Publishers, "Id", "StudioName");

            return View();
        }

     
        [HttpPost]
        public async Task<IActionResult> Create(NewGameVm game)
        {
            if (!ModelState.IsValid)
            {
                var gameDropdownsData = await _service.GetNewGameDropdownsValues();

                ViewBag.Developpers = new SelectList(gameDropdownsData.Developpers, "Id", "StudioName");
                ViewBag.Publishers = new SelectList(gameDropdownsData.Publishers, "Id", "StudioName");

                return View(game);
            }

            await _service.AddNewGameAsync(game);
            return RedirectToAction(nameof(Index));
        }

        //GET: Games/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var gameDetails = await _service.GetGameByIdAsync(id);
            if (gameDetails == null) return View("NotFound");

            var response = new NewGameVm()
            {
                Id = gameDetails.Id,
                Name = gameDetails.Name,
                Description = gameDetails.Description,
                Price = gameDetails.Price,
                ReleaseDate = gameDetails.ReleaseDate,
                ImageURL = gameDetails.ImageURL,
                GameCategory = gameDetails.GameCategory,
                DevelopperId = gameDetails.DevelopperId,
                PublisherIds = gameDetails.Games_Publishers.Select(n => n.PublisherId).ToList(),
            };

            var gameDropdownsData = await _service.GetNewGameDropdownsValues();
            ViewBag.Developpers = new SelectList(gameDropdownsData.Developpers, "Id", "StudioName");
            ViewBag.Publishers = new SelectList(gameDropdownsData.Publishers, "Id", "StudioName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewGameVm game)
        {
            if (id != game.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewGameDropdownsValues();

                ViewBag.Developpers = new SelectList(movieDropdownsData.Developpers, "Id", "StudioName");
                ViewBag.Publishers = new SelectList(movieDropdownsData.Publishers, "Id", "StudioName");

                return View(game);
            }

            await _service.UpdateGameAsync(game);
            return RedirectToAction(nameof(Index));
        }
    }
}
