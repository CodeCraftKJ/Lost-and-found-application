using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemManager.Data;
using ItemManager.Models.LostItems;
using Microsoft.EntityFrameworkCore;

namespace ItemManager.Repositories.LostItemRepository
{
    public class LostItemRepository : ILostItemRepository
    {
        private readonly DBContext _context;

        public LostItemRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LostItem>> GetAllLostItems()
        {
            return await _context.LostItems.ToListAsync();
        }

        public async Task<LostItem> GetLostItemById(int id)
        {
            return await _context.LostItems.FindAsync(id);
        }

        public async Task AddLostItem(LostItem item)
        {
            _context.LostItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLostItem(LostItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveLostItem(int id)
        {
            var item = await _context.LostItems.FindAsync(id);
            _context.LostItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
