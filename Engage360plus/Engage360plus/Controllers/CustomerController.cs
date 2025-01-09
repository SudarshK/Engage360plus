using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// Install packages MicrosoftEntityFrameworkCore.SqlServer and MicrosoftEntityFrameworkCore.Tools
namespace Engage360plus.Controllers
{
    //https://localhost:portnumber/api/customer
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //https://localhost:portnumber/api/customer
        [HttpGet]
        public IActionResult GetAllCustomers()
        {

            return Ok();
        }
    }
}
