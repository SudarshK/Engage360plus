using AutoMapper;
using Engage360plus.Models.Domain;
using Engage360plus.Models.DTO;
using Engage360plus.Repository;
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
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }
        //Post
        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody] AddCustomerRequestDto addCustomerRequestDto)
        {
            //Map DTO to Domain Model
            var customerDetailsModel = mapper.Map<CustomerDetails>(addCustomerRequestDto);
            await customerRepository.RegisterCustomerAsync(customerDetailsModel);
            //Map Domain Model to DTO
            return Ok(mapper.Map<CustomerDetailsDto>(customerDetailsModel));
        }

        //https://localhost:portnumber/api/customer
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customerDomainModel = await customerRepository.GetAllCustomerAsync();

            return Ok(mapper.Map<List<CustomerDetailsDto>>(customerDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult>GetCustomerById([FromRoute] Guid id)
        {
            var customerDomainModel= await customerRepository.GetCustomerByIdAsync(id);
            if(customerDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CustomerDetailsDto>(customerDomainModel));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute]Guid id, UpdateCustomerRequestDto updateCustomerRequestDto)
        {
            var customerDomainModel = mapper.Map<CustomerDetails>(updateCustomerRequestDto);
            customerDomainModel = await customerRepository.UpdateAsync(id,customerDomainModel);
            if(customerDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CustomerDetailsDto>(customerDomainModel));
        }
    }
}
