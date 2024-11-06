using answer.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace answer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await itemRepository.GetAllAsync();
            return Ok(items);
        }
    }
}
