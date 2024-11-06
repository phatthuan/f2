using answer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace answer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupJsonController : ControllerBase
    {
        private readonly string groupsUrl = "http://vnyi.ezitouch.com:85/resources/JsonData/Groups.json";

        private readonly HttpClient _httpClient;

        public GroupJsonController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await ReadGroupsFromUrlAsync();
            return Ok(groups);
        }

        private async Task<List<GroupJson>> ReadGroupsFromUrlAsync()
        {
            var json = await _httpClient.GetStringAsync(groupsUrl);
            return JsonSerializer.Deserialize<List<GroupJson>>(json);
        }
    }
}
