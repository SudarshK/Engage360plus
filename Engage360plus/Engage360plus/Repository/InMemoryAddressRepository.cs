using Engage360plus.Models.Domain;

namespace Engage360plus.Repository
{
    public class InMemoryAddressRepository:IAddressRepository
    {
        public Task<Addresses?> DeleteAddressAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Addresses?> GetAddressById(int id)
        {
            throw new NotImplementedException();
        }

        public async 
            Task<List<Addresses>> GetAllAddressesAsync()
        {
            return new List<Addresses>
            {
                new Addresses()
                {
                    AddressId = 12,
                    City = "Nagpur",
                    Country = "India",
                    PostalCode = "12345",
                    Region="Nagpur"
                }
            };
        }

        public Task<Addresses> RegisterAddressToCustomerAsync(Addresses addresses)
        {
            throw new NotImplementedException();
        }

        public Task<Addresses?> UpdateAddressAsync(int id, Addresses addresses)
        {
            throw new NotImplementedException();
        }
    }
}
