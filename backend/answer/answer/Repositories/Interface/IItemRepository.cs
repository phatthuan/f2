using answer.Models.Domain;
using answer.Models.DTO;

namespace answer.Repositories.Interface
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(int id);
        Task<Item?> UpdateOrderedQuantityAsync(int id, UpdateItemOrderedQuantityRequestDto request);
        Task<Item> CreateAsync(Item item);
        Task<Item?> DeleteAsync(int id);
        Task<List<Item?>> SearchAsync(string search);
    }
}
