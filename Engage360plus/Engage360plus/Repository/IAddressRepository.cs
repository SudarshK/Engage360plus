using Engage360plus.Models.Domain;

namespace Engage360plus.Repository
{
    public interface IAddressRepository
    {
        Task<List<Addresses>> GetAllAddressesAsync();
        Task<Addresses?> GetAddressById(Guid id);
        Task<Addresses> RegisterAddressToCustomerAsync(Addresses addresses);
        Task<Addresses?> UpdateAddressAsync(Guid id,Addresses addresses);
        Task<Addresses?> DeleteAddressAsync(Guid id);

    }
}
