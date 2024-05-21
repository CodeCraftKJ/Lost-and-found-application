using System.Collections.Generic;
using System.Threading.Tasks;
using ItemManager.Models.LostItems;

namespace ItemManager.Repositories.LostItemRepository
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
