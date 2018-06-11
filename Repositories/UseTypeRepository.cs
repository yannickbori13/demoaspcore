using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Repositories
{
    public class UseTypeRepository:Repository<UseType>,IUseTypeRepository
    {
        public UseTypeRepository(PicoleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
