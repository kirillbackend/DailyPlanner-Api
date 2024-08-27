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
    }
}
