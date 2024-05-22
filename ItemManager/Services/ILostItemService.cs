using ItemManager.Models.LostItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManager.Services
{
    public interface ILostItemService
    {
        Task<IEnumerable<LostItem>> GetAllAsync();
        Task<LostItem> GetByIdAsync(int id);
        Task AddAsync(LostItem lostItem);
        Task UpdateAsync(LostItem lostItem);
        Task DeleteAsync(int id);
    }
}
