using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Server.Data
{
    public class MediaLibraryDbContext : DbContext
    {
        public MediaLibraryDbContext() { }

        public MediaLibraryDbContext(DbContextOptions<MediaLibraryDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(b =>
            {
                b.Property(x => x.Name).IsRequired();
            });
        }
    }
}
