using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Repositories
{
    public class FermentableRepository:Repository<Fermentable>,IFermentableRepository
    {
        public FermentableRepository(PicoleDbContext dbContext) : base(dbContext)
        {

        }
    }
}
