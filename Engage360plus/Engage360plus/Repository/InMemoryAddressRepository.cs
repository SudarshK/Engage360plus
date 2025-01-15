using Engage360plus.Models.Domain;

namespace Engage360plus.Repository
{
    public class InMemoryAddressRepository:IAddressRepository
    {
        public Task<Addresses?> DeleteAddressAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Addresses?> GetAddressById(Guid id)
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
                    Id = Guid.Parse("c2b30590-bc31-42de-a9b5-a3054eba5b47"),
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

        public Task<Addresses?> UpdateAddressAsync(Guid id, Addresses addresses)
        {
            throw new NotImplementedException();
        }
    }
}
