using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly PicoleDbContext _dbContext;

        public UnitOfWork(PicoleDbContext dbContext)
        {
            _dbContext = dbContext;
            FermentableRepository = new FermentableRepository(dbContext);
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }

        public IFermentableRepository FermentableRepository { get; }
    }
}
