using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Repositories
{
    public class HopsRepository:Repository<Hops>,IHopsRepository
    {
        public HopsRepository(PicoleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
