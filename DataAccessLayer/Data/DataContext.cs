using CoreInfrastructureLayer.Helpers;
using Microsoft.EntityFrameworkCore;
using rick_morty_app.EntityLayer.Concrete;

namespace DataAccessLayer.Data
{
    public class DataContext : DbContext
    {
        private string DbPath { get; set; }
        public DataContext()
        {
            DbPath = WorkspacePaths.Instance.DbPath!;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        // DbSet properties
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Maybe I can add some configurations here but now I don't need it.
        }
    }
}
