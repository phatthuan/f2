using answer.Data;
using answer.Models.Domain;
using answer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace answer.Repositories.Implementation
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ItemRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await dbContext.Items.ToListAsync();
        }
    }
}
