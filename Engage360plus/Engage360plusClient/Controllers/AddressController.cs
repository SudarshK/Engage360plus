using Engage360plusUI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Engage360plusUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AddressController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<AddressDto> response = new List<AddressDto>();
            try
            {
                //GetAllAddresses from WebAPI
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7131/api/Addresses");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<AddressDto>>());
            }
            catch (Exception ex)
            {
                //Log
            }

            return View(response);
        }
    }
}
