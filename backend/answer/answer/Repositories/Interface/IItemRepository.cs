using answer.Models.Domain;

namespace answer.Repositories.Interface
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
    }
}
