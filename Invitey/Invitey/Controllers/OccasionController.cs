using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invitey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostOccasion()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOccasion()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOccasion()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOccasion()
        {
            return Ok();
        }
    }
}
