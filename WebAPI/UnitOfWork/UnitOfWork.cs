using Microsoft.EntityFrameworkCore;
using WebAPI.DataContext;
using WebAPI.DataModel;
using WebAPI.Repository;

namespace WebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        //private CardSystemDataContext context = new CardSystemDataContext();
        private CardSystemDataContext context;
        //public GenericRepository<Card> Card { get; private set; }
        //public GenericRepository<CardContent> CardContent { get; private set; }
        public ICardRepository Card { get; }

        public ICardContentRepository CardContent { get; }


        //public UnitOfWork(IConfiguration configuration)
        //{
        //    //this.context = new CardSystemDataContext();

        //    this.context = new CardSystemDataContext(configuration.GetConnectionString("WebAPIDatabase"));

        //var optionsBuilder = new DbContextOptionsBuilder<CardSystemDataContext>();
        //optionsBuilder.UseSqlServer(Configuration.GetConnectionStringSecureValue("DefaultConnection"));
        //    this.context = new CardSystemDataContext(optionsBuilder.Options);
        //}

        public UnitOfWork(CardSystemDataContext context,
            ICardRepository card,
            ICardContentRepository cardContent)
        {
            this.context = context;
            //this.Card = new CardRepository(this.context);
            //this.CardContent = new CardContentRepository(this.context);
            //this.CardContent = new GenericRepository<CardContent>(this.context);
            this.Card = card;
            this.CardContent = cardContent;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        public int Complete()
        {
            return this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
