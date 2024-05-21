using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using ItemManager.Models.FoundItems;
using ItemManager.Models.LostItems;

namespace ItemManager.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<LostItem> LostItems { get; set; }
        public DbSet<FoundItem> FoundItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
