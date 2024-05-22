using ItemManager.Models.FoundItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManager.Services
{
    public interface IFoundItemService
    {
        Task<IEnumerable<FoundItem>> GetAllAsync();
        Task<FoundItem> GetByIdAsync(int id);
        Task AddAsync(FoundItem foundItem);
        Task UpdateAsync(FoundItem foundItem);
        Task DeleteAsync(int id);
    }
}
