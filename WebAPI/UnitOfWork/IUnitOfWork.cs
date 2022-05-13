using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICardRepository Card { get; }
        ICardContentRepository CardContent { get; }
        int Save();
    }
}
