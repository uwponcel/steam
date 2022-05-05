using steam.Data.Base;
using steam.Data.ViewModels;
using steam.Models;
using System.Threading.Tasks;

namespace steam.Data.Services
{
    public interface IGamesService : IEntitiyBaseRepository<Game>
    {
        Task<Game> GetGameByIdAsync(int id);
        Task<NewGameDropdownsVm> GetNewGameDropdownsValues();
        Task AddNewGameAsync(NewGameVm data);
        Task UpdateGameAsync(NewGameVm data);
    }
}
