using Microsoft.EntityFrameworkCore;
using WebAPI.DataModel;

namespace WebAPI.DataContext
{
    public class CardSystemDataContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Card> Card { get; set; }
        public DbSet<CardContent> CardContent { get; set; }

        public CardSystemDataContext(DbContextOptions<CardSystemDataContext> options) : base(options)
        {
        }

        //public CardSystemDataContext(IConfiguration configuration)
        //{
        //    configuration.GetConnectionString("WebAPIDatabase");
        //}
        //public CardSystemDataContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure the model using ModelBuilder Fluent API.
            //modelBuilder.Entity<Student>()
            //.HasOne<Grade>(s => s.Grade)
            //.WithMany(g => g.Students)
            //.HasForeignKey(s => s.CurrentGradeId);
        }
    }
}
