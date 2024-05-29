using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ItemManager.Models.FoundItems;
using ItemManager.Models.LostItems;

namespace ItemManager.Data
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DBContext(DbContextOptions<DBContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<LostItem> LostItems { get; set; }
        public DbSet<FoundItem> FoundItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var defaultConnection = _configuration.GetSection("AppSettings:DefaultConnection").Value;
                optionsBuilder.UseSqlServer(defaultConnection);
            }
        }
    }
}
