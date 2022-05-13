using WebAPI.DataModel;

namespace WebAPI.Repository
{
    public interface ICardRepository : IGenericRepository<Card>
    {
        Task<Card> GetWithDetails(int id);
    }
}
