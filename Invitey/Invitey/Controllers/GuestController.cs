using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invitey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        [HttpPost]
        [Route("AddGuest")]
        public async Task<IActionResult> AddGuest()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetAllGuest")]
        public async Task<IActionResult> GetAllGuest()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetByIdGuest")]
        public async Task<IActionResult> GetByIdGuest()
        {
            return Ok();
        }

        [HttpPut]
        [Route("EditGuest")]
        public async Task<IActionResult> UpdateOccasion()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteGuest")]
        public async Task<IActionResult> DeleteOccasion()
        {
            return Ok();
        }
    }
}
