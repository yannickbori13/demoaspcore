
namespace Picole.WebApi.Repositories.Core
{
    public interface IUnitOfWork
    {
        void Complete();
        IFermentableRepository FermentableRepository { get; }
    
    }
}
