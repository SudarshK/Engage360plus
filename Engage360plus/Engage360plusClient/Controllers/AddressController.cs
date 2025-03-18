using Engage360plusUI.Models;
using Engage360plusUI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
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

                var httpResponseMessage = await client.GetAsync("http://localhost:5189/api/Addresses");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<AddressDto>>());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
                RequestUri = new Uri("http://localhost:5189/api/Addresses"),
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

        [HttpGet]
        public async Task<IActionResult>Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<AddressDto>($"http://localhost:5189/api/Addresses/id:Guid?id={id.ToString()}");
            if (response is not null)
            {
                return View(response);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddressDto request)
        {
            var client =httpClientFactory.CreateClient();
            var httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"http://localhost:5189/api/Addresses/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };
            var httpResponseMessage = await client.SendAsync(httpRequest);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadFromJsonAsync<AddressDto>();
            if (response is not null)
            {
                return RedirectToAction("Edit", "Address");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AddressDto request)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponse = await client.DeleteAsync($"http://localhost:5189/api/Addresses/{request.Id}");
                httpResponse.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "Address");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View("Edit");
        }
    }
}
