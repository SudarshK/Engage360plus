using Engage360plusUI.Models;
using Engage360plusUI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAddressViewModel model)
        {
            var client = httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7131/api/Addresses"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<AddressDto>();
            if (response is not null)
            {
                return RedirectToAction("Index","Address");
            }
            return View();
        }
    }
}
