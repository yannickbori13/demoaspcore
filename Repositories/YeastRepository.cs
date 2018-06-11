
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Repositories
{
    public class YeastRepository:Repository<Yeast>,IYeastRepository
    {
        public YeastRepository(PicoleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
