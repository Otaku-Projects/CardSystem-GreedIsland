using Microsoft.EntityFrameworkCore;
using WebAPI.DataContext;
using WebAPI.DataModel;

namespace WebAPI.Repository
{
    public class CardContentRepository : GenericRepository<CardContent>, ICardContentRepository
    {
        public CardContentRepository(CardSystemDataContext _context) : base(_context)
        {
        }
    }
}
