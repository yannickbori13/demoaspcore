using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Repositories
{
    public class FermenterChamberConfigurationRepository:Repository<FermenterChamberConfiguration>,IFermenterChamberConfigurationRepository
    {
        public FermenterChamberConfigurationRepository(PicoleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
