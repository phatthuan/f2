using answer.Repositories.Implementation;
using answer.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace answer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await groupRepository.GetAllAsync();
            return Ok(groups);
        }
    }
}
