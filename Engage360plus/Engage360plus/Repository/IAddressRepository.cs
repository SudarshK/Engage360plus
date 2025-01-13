using Engage360plus.Models.Domain;

namespace Engage360plus.Repository
{
    public interface IAddressRepository
    {
        Task<List<Addresses>> GetAllAddressesAsync();
        Task<Addresses?> GetAddressById(int id);
        Task<Addresses> RegisterAddressToCustomerAsync(Addresses addresses);
        Task<Addresses?> UpdateAddressAsync(int id,Addresses addresses);
        Task<Addresses?> DeleteAddressAsync(int id);

    }
}
