using Engage360plus.Models.Domain;

namespace Engage360plus.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerDetails> RegisterCustomerAsync(CustomerDetails customerDetails);
        Task<List<CustomerDetails>> GetAllCustomerAsync();
        Task<CustomerDetails?> GetCustomerByIdAsync(int id);
    }
}
