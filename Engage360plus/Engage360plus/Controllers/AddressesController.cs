using AutoMapper;
using Engage360plus.Data;
using Engage360plus.Models.Domain;
using Engage360plus.Models.DTO;
using Engage360plus.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Engage360plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly CRMDbContext dbContext;
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;

        public AddressesController(CRMDbContext dbContext, IAddressRepository addressRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAddressToCustomer([FromBody] AddAddresstoCustomerDto addAddressesdto)
        {
            var addressDomainModel = mapper.Map<Addresses>(addAddressesdto);
            //var addressDomainModel = new Addresses
            //{
            //    AddressId = addAddressesdto.AddressId,
            //    City = addAddressesdto.City,
            //    Country = addAddressesdto.Country,
            //    PostalCode = addAddressesdto.PostalCode,
            //    Region = addAddressesdto.Region
            //};
            //await dbContext.Addresses.AddAsync(addressDomainModel);
            addressDomainModel = await addressRepository.RegisterAddressToCustomerAsync(addressDomainModel);
            //var addressDto = new AddressesDto
            //{
            //    AddressId = addressDomainModel.AddressId,
            //    City = addressDomainModel.City,
            //    Country = addressDomainModel.Country,
            //    PostalCode = addressDomainModel.PostalCode,
            //    Region = addressDomainModel.Region
            //};
            var addressDto = mapper.Map<AddAddresstoCustomerDto>(addAddressesdto);
            return CreatedAtAction(nameof(RegisterAddressToCustomer), new { id = addressDto.AddressId }, addressDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAddressAsync([FromRoute] int id, [FromBody] UpdateAddressDto updateAddressDto)
        {
            //var addressDomainModel = await dbContext.Addresses.FirstOrDefaultAsync(x => x.AddressId == id);
            var addressDomainModel = mapper.Map<Addresses>(updateAddressDto);
            //var addressDomainModel = new Addresses
            //{
            //    Country = updateAddressDto.Country,
            //    City = updateAddressDto.City,
            //    Region = updateAddressDto.Region,
            //    PostalCode = updateAddressDto.PostalCode
            //};
            addressDomainModel = await addressRepository.UpdateAddressAsync(id, addressDomainModel);
            if (addressDomainModel == null)
            {
                return NotFound();
            }

            var addressDto = mapper.Map<AddressesDto>(addressDomainModel);
            //var addressDto = new Addresses
            //{
            //    City = addressDomainModel.City,
            //    Country = addressDomainModel.Country,
            //    PostalCode = addressDomainModel.PostalCode,
            //    Region = addressDomainModel.Region
            //};


            return Ok(addressDto);
        }

        //GET: http://localhost:portnumber/
        [HttpGet]
        public async Task<IActionResult> GetAllAddressesAsync()
        {
            //var addressesDomain = await dbContext.Addresses.ToListAsync();
            var addressesDomain = await addressRepository.GetAllAddressesAsync();
            //var addressDto = new List<AddressesDto>();
            //foreach (var addressDomain in addressesDomain)
            //{
            //    addressDto.Add(new AddressesDto()
            //    {
            //        AddressId = addressDomain.AddressId,
            //        City = addressDomain.City,
            //        Region = addressDomain.Region,
            //        PostalCode = addressDomain.PostalCode,
            //        Country = addressDomain.Country
            //    });
            //}

            //Map Domain Model to Dto
            var addressDto = mapper.Map<List<AddressesDto>>(addressesDomain);
            return Ok(addressDto);
        }

        [HttpGet]
        [Route("id:int")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            //var address = dbContext.Addresses.Find(id);
            //var address = await dbContext.Addresses.FirstOrDefaultAsync(x => x.AddressId == id);
            var address = await addressRepository.GetAddressById(id);

            if (address == null)
            {
                return NotFound("Address not found");
            }

            //var addressDto = new AddressesDto
            //{
            //    City = address.City,
            //    Region = address.Region,
            //    PostalCode = address.PostalCode,
            //    Country = address.Country
            //};
            return Ok(mapper.Map<AddressesDto>(address));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAddressAsync([FromRoute] int id)
        {
            //var addressDomainModel= await dbContext.Addresses.FirstOrDefaultAsync(x => x.AddressId == id);
            var addressDomainModel = await addressRepository.DeleteAddressAsync(id);
            if (addressDomainModel == null)
            {
                return NotFound();
            }
            //var addressDto = new Addresses
            //{
            //    AddressId = addressDomainModel.AddressId,
            //    City = addressDomainModel.City,
            //    Country = addressDomainModel.Country,
            //    PostalCode = addressDomainModel.PostalCode,
            //    Region = addressDomainModel.Region
            //};
            return Ok(mapper.Map<AddressesDto>(addressDomainModel));
        }
    }
}
