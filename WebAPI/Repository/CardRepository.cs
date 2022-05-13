using Microsoft.EntityFrameworkCore;
using WebAPI.DataContext;
using WebAPI.DataModel;

namespace WebAPI.Repository
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        public CardRepository(CardSystemDataContext _context) : base(_context)
        {
        }

        public async Task<Card> GetWithDetails(int id)
        {
            return await this.GetById(f=>f.Id == id).FirstOrDefaultAsync();
        }
    }
}
