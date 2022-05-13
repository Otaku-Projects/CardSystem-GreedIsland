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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //IConfigurationRoot configuration = new ConfigurationBuilder()
        //    //    .SetBasePath(Directory.GetCurrentDirectory())
        //    //    .AddJsonFile("Secrets.json")
        //    //    .Build();
        //    //string connectionString = configuration.GetConnectionString("WebAPIDatabase");

        //    optionsBuilder.UseSqlServer(@"Data Source=C027\\SQLEXPRESS19;Initial Catalog=CardManagementSystem;Persist Security Info=True;User ID=sa;Password=P@ssw0rd;MultipleActiveResultSets=True");

        //    //optionsBuilder.UseSqlServer(connectionString);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /***
             * you may configure the model relationship using ModelBuilder Fluent API.
             * 
             * Fluent API is used to configure domain classes to override conventions
             * *
             * but i don't use the Fluent API, I use the data model
             * please read https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
             * */

            //modelBuilder.Entity<Student>()
            //.HasOne<Grade>(s => s.Grade)
            //.WithMany(g => g.Students)
            //.HasForeignKey(s => s.CurrentGradeId);
        }
    }
}
