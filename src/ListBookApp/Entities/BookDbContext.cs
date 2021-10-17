using ListBookApp.Entites.Configs;
using Microsoft.EntityFrameworkCore;

namespace ListBookApp.Entites
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {}
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Apply configurations for database from configurations classes
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}