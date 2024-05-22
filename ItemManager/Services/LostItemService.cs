using ItemManager.Models.LostItems;
using ItemManager.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManager.Services
{
    public class LostItemService : ILostItemService
    {
        private readonly ILostItemRepository _repository;

        public LostItemService(ILostItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LostItem>> GetAllAsync()
        {
            return await _repository.GetAllLostItems();
        }

        public async Task<LostItem> GetByIdAsync(int id)
        {
            return await _repository.GetLostItemById(id);
        }

        public async Task AddAsync(LostItem lostItem)
        {
            await _repository.AddLostItem(lostItem);
        }

        public async Task UpdateAsync(LostItem lostItem)
        {
            await _repository.UpdateLostItem(lostItem);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.RemoveLostItem(id);
        }
    }
}
