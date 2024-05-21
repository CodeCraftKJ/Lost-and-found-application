using System.Collections.Generic;
using System.Threading.Tasks;
using ItemManager.Models.FoundItems;

namespace ItemManager.Repositories.FoundItemRepository
{
    public interface IFoundItemRepository
    {
        Task<IEnumerable<FoundItem>> GetAllFoundItems();
        Task<FoundItem> GetFoundItemById(int id);
        Task AddFoundItem(FoundItem item);
        Task UpdateFoundItem(FoundItem item);
        Task RemoveFoundItem(int id);
    }
}
