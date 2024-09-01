using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DailyPlanner_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("pass");
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(id);
        }
    }
}
