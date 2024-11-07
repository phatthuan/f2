using answer.Data;
using answer.Models.Domain;
using answer.Models.DTO;
using answer.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Item> CreateAsync(Item item)
        {
            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<Item?> DeleteAsync(int id)
        {
            var existingItem = await dbContext.Items.FirstOrDefaultAsync(x => x.ItemID == id);
            if (existingItem != null)
            {
                dbContext.Items.Remove(existingItem);
                await dbContext.SaveChangesAsync();
                return existingItem;
            }

            return null;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await dbContext.Items.ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await dbContext.Items.FirstOrDefaultAsync(x => x.ItemID == id);
        }

        public async Task<List<Item?>> SearchAsync(string search)
        {
            return await dbContext.Items.Where(x => search == null 
            || x.ItemName.ToLower().Contains(search.ToLower()) 
            || x.ItemName1.ToLower().Contains(search.ToLower()) 
            || x.GroupName.ToLower().Contains(search.ToLower())).ToListAsync();
        }

        public async Task<Item?> UpdateOrderedQuantityAsync(int id, UpdateItemOrderedQuantityRequestDto request)
        {
            var existingItem = await dbContext.Items.FirstOrDefaultAsync(x => x.ItemID == id);

            if (existingItem == null)
            {
                return null;
            }

            var item = new Item
            {
                ItemID = id,
                ItemName = existingItem.ItemName,
                ItemName1 = existingItem.ItemName1,
                UomName = existingItem.UomName,
                ItemUrlImage = existingItem.ItemUrlImage,
                ItemDisplayOrder = existingItem.ItemDisplayOrder,
                ItemPriceInclTax = existingItem.ItemPriceInclTax,
                ItemPrice = existingItem.ItemPrice,
                CurName = existingItem.CurName,
                GroupID = existingItem.GroupID,
                GroupName = existingItem.GroupName,
                OrderedQuantity = request.OrderedQuantity,
                ItemDescription = existingItem.ItemDescription,
            };

            dbContext.Entry(existingItem).CurrentValues.SetValues(item);

            await dbContext.SaveChangesAsync();
            return item;
        }
    }
}
