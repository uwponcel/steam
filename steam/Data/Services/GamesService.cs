using Microsoft.EntityFrameworkCore;
using steam.Data.Base;
using steam.Data.ViewModels;
using steam.Models;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Data.Services
{
    public class GamesService:EntityBaseRepository<Game>,IGamesService
    {
        private readonly AppDbContext _context;
        public GamesService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddNewGameAsync(NewGameVm data)
        {
            var newGame = new Game()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ReleaseDate = data.ReleaseDate,
                GameCategory = data.GameCategory,
                DevelopperId = data.DevelopperId

            };

            await _context.Games.AddAsync(newGame);
            await _context.SaveChangesAsync();

            // Add game publishers
            foreach (var publisherId in data.PublisherIds)
            {
                var newGamePublisher = new Game_Publisher()
                {
                    GameId = newGame.Id,
                    PublisherId = publisherId,
                };
                await _context.Games_Publishers.AddAsync(newGamePublisher);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            var gameDetails = await _context.Games
                .Include(d => d.Developper)
                .Include(gp => gp.Games_Publishers).ThenInclude(p => p.Publisher)
                .FirstOrDefaultAsync(n => n.Id == id);

            return gameDetails;
        }

        public async Task<NewGameDropdownsVm> GetNewGameDropdownsValues()
        {
            var response = new NewGameDropdownsVm()
            {
                Developpers = await _context.Developpers.OrderBy(n => n.StudioName).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.StudioName).ToListAsync()
            };

            return response;
  
        }

        public async Task UpdateGameAsync(NewGameVm data)
        {
            var dbGame = await _context.Games.FirstOrDefaultAsync(n=> n.Id == data.Id);

            if (dbGame != null)
            {
                dbGame.Name = data.Name;
                dbGame.Description = data.Description;
                dbGame.Price = data.Price;
                dbGame.ImageURL = data.ImageURL;
                dbGame.ReleaseDate = data.ReleaseDate;
                dbGame.GameCategory = data.GameCategory;
                dbGame.DevelopperId = data.DevelopperId;
                await _context.SaveChangesAsync();
                
            }

            //Remove existing publishers
            var existingPublishersDb = _context.Games_Publishers.Where(n=>n.GameId == data.Id).ToList();
            _context.Games_Publishers.RemoveRange(existingPublishersDb);
            await _context.SaveChangesAsync();

       

            // Add game publishers
            foreach (var publisherId in data.PublisherIds)
            {
                var newGamePublisher = new Game_Publisher()
                {
                    GameId = data.Id,
                    PublisherId = publisherId,
                };
                await _context.Games_Publishers.AddAsync(newGamePublisher);
            }
            await _context.SaveChangesAsync();
        }
    }
}
