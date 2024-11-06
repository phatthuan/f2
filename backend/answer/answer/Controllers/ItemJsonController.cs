using answer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace answer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemJsonController : ControllerBase
    {
        private readonly string itemsUrl = "http://vnyi.ezitouch.com:85/resources/JsonData/Items.json";

        private readonly HttpClient _httpClient;

        public ItemJsonController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await ReadItemsFromUrlAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var items = await ReadItemsFromUrlAsync();
            var item = items.FirstOrDefault(i => i.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        private async Task<List<ItemJson>> ReadItemsFromUrlAsync()
        {
            var json = await _httpClient.GetStringAsync(itemsUrl);
            return JsonSerializer.Deserialize<List<ItemJson>>(json);
        }
    }
}
