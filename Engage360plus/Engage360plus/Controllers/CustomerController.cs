using AutoMapper;
using Engage360plus.CustomActionFilters;
using Engage360plus.Models.Domain;
using Engage360plus.Models.DTO;
using Engage360plus.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// Install packages MicrosoftEntityFrameworkCore.SqlServer and MicrosoftEntityFrameworkCore.Tools
namespace Engage360plus.Controllers
{
    //https://localhost:portnumber/api/customer
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }
        //Post
        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody] AddCustomerRequestDto addCustomerRequestDto)
        {           
                //Map DTO to Domain Model
                var customerDetailsModel = mapper.Map<CustomerDetails>(addCustomerRequestDto);
                await customerRepository.RegisterCustomerAsync(customerDetailsModel);
                //Map Domain Model to DTO
                return Ok(mapper.Map<CustomerDetailsDto>(customerDetailsModel));
        }

        //https://localhost:portnumber/api/customer?filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery]string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize=10)
        {
            var customerDomainModel = await customerRepository.GetAllCustomerAsync(filterOn, filterQuery,sortBy,isAscending,pageNumber,pageSize);
            throw new Exception("This is a new exception");   
            return Ok(mapper.Map<List<CustomerDetailsDto>>(customerDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid id)
        {
            
                var customerDomainModel = await customerRepository.GetCustomerByIdAsync(id);
                if (customerDomainModel == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<CustomerDetailsDto>(customerDomainModel));
           
        }

        [ValidateModel]
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, UpdateCustomerRequestDto updateCustomerRequestDto)
        {
                var customerDomainModel = mapper.Map<CustomerDetails>(updateCustomerRequestDto);
                customerDomainModel = await customerRepository.UpdateAsync(id, customerDomainModel);
                if (customerDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<CustomerDetailsDto>(customerDomainModel));
            
        }
    }
}
