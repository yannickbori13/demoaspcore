
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Repositories
{
    public class UnitRepository:Repository<Unit>,IUnitRepository
    {
        public UnitRepository(PicoleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
