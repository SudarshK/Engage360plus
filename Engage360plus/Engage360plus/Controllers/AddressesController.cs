using AutoMapper;
using Engage360plus.Data;
using Engage360plus.Models.Domain;
using Engage360plus.Models.DTO;
using Engage360plus.Repository;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> RegisterAddressToCustomer([FromBody] AddAddresstoCustomerDto addAddressesdto)
        {
            if (ModelState.IsValid == true)
            {
                var addressDomainModel = mapper.Map<Addresses>(addAddressesdto);
                //var addressDomainModel = new Addresses
                //{
                //    Id = addAddressesdto.Id,
                //    City = addAddressesdto.City,
                //    Country = addAddressesdto.Country,
                //    PostalCode = addAddressesdto.PostalCode,
                //    Region = addAddressesdto.Region
                //};
                //await dbContext.Addresses.AddAsync(addressDomainModel);
                addressDomainModel = await addressRepository.RegisterAddressToCustomerAsync(addressDomainModel);
                //var addressDto = new AddressesDto
                //{
                //    Id = addressDomainModel.Id,
                //    City = addressDomainModel.City,
                //    Country = addressDomainModel.Country,
                //    PostalCode = addressDomainModel.PostalCode,
                //    Region = addressDomainModel.Region
                //};
                var addressDto = mapper.Map<AddressesDto>(addressDomainModel);
                return CreatedAtAction(nameof(RegisterAddressToCustomer), new { id = addressDto.Id }, addressDto);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Authorize(Roles = "Writer")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAddressAsync([FromRoute] Guid id, [FromBody] UpdateAddressDto updateAddressDto)
        {
            if (ModelState.IsValid == true)
            {
                //var addressDomainModel = await dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
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
            return BadRequest(ModelState);
        }

        //GET: http://localhost:portnumber/
        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAllAddressesAsync()
        {
            if (ModelState.IsValid == true)
            {
                //var addressesDomain = await dbContext.Addresses.ToListAsync();
                var addressesDomain = await addressRepository.GetAllAddressesAsync();
                //var addressDto = new List<AddressesDto>();
                //foreach (var addressDomain in addressesDomain)
                //{
                //    addressDto.Add(new AddressesDto()
                //    {
                //        Id = addressDomain.Id,
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
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        [Route("id:Guid")]
        public async Task<IActionResult> GetAddressById(Guid id)
        {
            if (ModelState.IsValid == true)
            {
                //var address = dbContext.Addresses.Find(id);
                //var address = await dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
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
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Authorize(Roles = "Writer,Reader")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAddressAsync([FromRoute] Guid id)
        {
            if (ModelState.IsValid == true)
            {
                //var addressDomainModel= await dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                var addressDomainModel = await addressRepository.DeleteAddressAsync(id);
                if (addressDomainModel == null)
                {
                    return NotFound();
                }
                //var addressDto = new Addresses
                //{
                //    Id = addressDomainModel.Id,
                //    City = addressDomainModel.City,
                //    Country = addressDomainModel.Country,
                //    PostalCode = addressDomainModel.PostalCode,
                //    Region = addressDomainModel.Region
                //};
                return Ok(mapper.Map<AddressesDto>(addressDomainModel));
            }
            return BadRequest(ModelState);
        }
    }
}
