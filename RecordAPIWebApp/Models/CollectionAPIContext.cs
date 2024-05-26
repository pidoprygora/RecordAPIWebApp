using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RecordAPIWebApp.Models
{
    public class CollectionAPIContext : DbContext
    {
        public CollectionAPIContext(DbContextOptions<CollectionAPIContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Artist> Artists { get; set; } 

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Record> Records { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        
    }
}
