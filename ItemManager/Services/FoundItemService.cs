using ItemManager.Models.FoundItems;
using ItemManager.Repositories;
using ItemManager.Repositories.FoundItemRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManager.Services
{
    public class FoundItemService : IFoundItemService
    {
        private readonly IFoundItemRepository _repository;

        public FoundItemService(IFoundItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FoundItem>> GetAllAsync()
        {
            return await _repository.GetAllFoundItems();
        }

        public async Task<FoundItem> GetByIdAsync(int id)
        {
            return await _repository.GetFoundItemById(id);
        }

        public async Task AddAsync(FoundItem foundItem)
        {
            await _repository.AddFoundItem(foundItem);
        }

        public async Task UpdateAsync(FoundItem foundItem)
        {
            await _repository.UpdateFoundItem(foundItem);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.RemoveFoundItem(id);
        }
    }
}
