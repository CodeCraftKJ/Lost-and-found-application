using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemManager.Data;
using ItemManager.Models.FoundItems;
using Microsoft.EntityFrameworkCore;

namespace ItemManager.Repositories.FoundItemRepository
{
    public class FoundItemRepository : IFoundItemRepository
    {
        private readonly DBContext _context;

        public FoundItemRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoundItem>> GetAllFoundItems()
        {
            return await _context.FoundItems.ToListAsync();
        }

        public async Task<FoundItem> GetFoundItemById(int id)
        {
            return await _context.FoundItems.FindAsync(id);
        }

        public async Task AddFoundItem(FoundItem item)
        {
            _context.FoundItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFoundItem(FoundItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFoundItem(int id)
        {
            var item = await _context.FoundItems.FindAsync(id);
            _context.FoundItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
