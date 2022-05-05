using Microsoft.EntityFrameworkCore;
using steam.Data.Base;
using steam.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Data.Services
{
    public class PublishersService : EntityBaseRepository<Publisher>, IPublishersService
    {
        public PublishersService(AppDbContext context):base(context){}
   
    }
}
