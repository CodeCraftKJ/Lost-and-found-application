using ItemManager.Models.LostItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManager.Repositories
{
    public interface ILostItemRepository
    {
        Task<IEnumerable<LostItem>> GetAllLostItems();
        Task<LostItem> GetLostItemById(int id);
        Task AddLostItem(LostItem item);
        Task UpdateLostItem(LostItem item);
        Task RemoveLostItem(int id);
    }
}
