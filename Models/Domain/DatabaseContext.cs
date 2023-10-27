using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Domain
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }

        public DbSet<Generale> Generale { set; get; }
        public DbSet<Author> Author { set; get; }
        public DbSet<Publisher> Publisher { set; get; }
        public DbSet<Book> Book { set; get; }
    }
}
