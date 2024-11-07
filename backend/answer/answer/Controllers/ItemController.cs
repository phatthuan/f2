using answer.Models.Domain;
using answer.Models.DTO;
using answer.Repositories.Interface;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace answer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository itemRepository;
        private readonly IGroupRepository groupRepository;

        public ItemController(IItemRepository itemRepository, IGroupRepository groupRepository)
        {
            this.itemRepository = itemRepository;
            this.groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await itemRepository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await itemRepository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemOrderedQuantity(int id, [FromBody] UpdateItemOrderedQuantityRequestDto request)
        {
            var item = await itemRepository.UpdateOrderedQuantityAsync(id, request);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemRequestDto request)
        {
            var item = new Item
            {
                ItemName = request.ItemName,
                ItemName1 = request.ItemName1,
                UomName = request.UomName,
                ItemUrlImage = request.ItemUrlImage,
                ItemDisplayOrder = request.ItemDisplayOrder,
                ItemPriceInclTax = request.ItemPriceInclTax,
                ItemPrice = request.ItemPrice,
                CurName = request.CurName,
                GroupID = request.GroupID,
                GroupName = request.GroupName,
                OrderedQuantity = request.OrderedQuantity,
                ItemDescription = request.ItemDescription,
            };
            var group = await groupRepository.GetByIdAsync(request.GroupID);
            if (group == null)
            {
                return BadRequest("Group ID error");
            }
            item = await itemRepository.CreateAsync(item);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await itemRepository.DeleteAsync(id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchItems(string? search)
        {
            var items = await itemRepository.SearchAsync(search);
            if (items == null || items.Count == 0) { return NotFound(); };
            return Ok(items);
        }
    }
}
