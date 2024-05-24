using Microsoft.EntityFrameworkCore;
using ItemManager.Models.FoundItems;
using ItemManager.Models.LostItems;

namespace ItemManager.Data
{
    public class DBContext : DbContext
    {
        private readonly string _connectionString;

        public DBContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<LostItem> LostItems { get; set; }
        public DbSet<FoundItem> FoundItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
