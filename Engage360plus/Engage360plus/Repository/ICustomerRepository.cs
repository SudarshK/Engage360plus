using Engage360plus.Models.Domain;

namespace Engage360plus.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerDetails> RegisterCustomerAsync(CustomerDetails customerDetails);
        Task<List<CustomerDetails>> GetAllCustomerAsync(string? filterOn=null,string? filterQuery=null,string? sortBy=null, bool isAscending=true,int pageNumber=1,int pageSize=10);
        Task<CustomerDetails?> GetCustomerByIdAsync(Guid id);
        Task<CustomerDetails?> UpdateAsync(Guid id, CustomerDetails customerDetails);
    }
}
