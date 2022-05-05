using steam.Data.Base;
using steam.Models;

namespace steam.Data.Services
{
    public class DeveloppersService:EntityBaseRepository<Developper>, IDeveloppersService
    {
        public DeveloppersService(AppDbContext context) : base(context)
        {

        }
    }
}
