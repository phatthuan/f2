using answer.Data;
using answer.Models.Domain;
using answer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace answer.Repositories.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext dbContext;
        public GroupRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await dbContext.Groups.ToListAsync();
        }

        public async Task<Group?> GetByIdAsync(int id)
        {
            return await dbContext.Groups.FirstOrDefaultAsync(x => x.GroupID == id);
        }
    }
}
