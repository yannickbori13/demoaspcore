
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Repositories
{
    public class ExtraRepository:Repository<Extra>,IExtraRepository
    {
        public ExtraRepository(PicoleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
