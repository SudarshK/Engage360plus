using Engage360plus.Data;
using Engage360plus.Models.Domain;
using Engage360plus.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Engage360plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly CRMDbContext dbContext;

        public AddressesController(CRMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult RegisterAddressToCustomer([FromBody] AddAddresstoCustomerDto addressesdto)
        {
            var addressDomainModel = new Addresses
            {
                City = addressesdto.City,
                Country = addressesdto.Country,
                PostalCode = addressesdto.PostalCode,
                Region = addressesdto.Region
            };
            dbContext.Addresses.Add(addressDomainModel);
            dbContext.SaveChanges();
            var addressDto = new AddressesDto
            {
                City = addressDomainModel.City,
                Country = addressDomainModel.Country,
                PostalCode = addressDomainModel.PostalCode,
                Region = addressDomainModel.Region
            };
            return CreatedAtAction(nameof(RegisterAddressToCustomer), new { id = addressDto.AddressId},addressDto);
        }
        //GET: http://localhost:portnumber/
        [HttpGet]
        public IActionResult GetAllAddresses()
        {
            var addressesDomain = dbContext.Addresses.ToList();
            var addressDto = new List<AddressesDto>();
            foreach (var addressDomain in addressesDomain)
            {
                addressDto.Add(new AddressesDto()
                {
                    City = addressDomain.City,
                    Region = addressDomain.Region,
                    PostalCode = addressDomain.PostalCode,
                    Country = addressDomain.Country
                });    
                
            }
            return Ok(addressDto);
        }

        [HttpGet]
        [Route("id:int")]
        public IActionResult GetAddressById(int id)
        {
            //var address = dbContext.Addresses.Find(id);
            var address = dbContext.Addresses.FirstOrDefault(x=>x.AddressId==id);

            if(address == null)
            {
                return NotFound("Address not found");
            }

            var addressDto = new AddressesDto
            {
                City = address.City,
                Region = address.Region,
                PostalCode = address.PostalCode,
                Country = address.Country
            };
            return Ok(address);
        }
    }
}
