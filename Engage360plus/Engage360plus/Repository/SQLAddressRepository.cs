using Engage360plus.Data;
using Engage360plus.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Engage360plus.Repository
{
    public class SQLAddressRepository:IAddressRepository
    {
        private readonly CRMDbContext dbContext;

        public SQLAddressRepository(CRMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Addresses?> DeleteAddressAsync(int id)
        {
            var existingAddress= await dbContext.Addresses.FirstOrDefaultAsync(x=>x.AddressId==id);
            if (existingAddress == null)
            {
                return null;
            }
            dbContext.Addresses.Remove(existingAddress);
            await dbContext.SaveChangesAsync();
            return existingAddress;
        }

        public async Task<Addresses?> GetAddressById(int id)
        {
            return await dbContext.Addresses.FirstOrDefaultAsync(x => x.AddressId == id);
        }

        public async Task<List<Addresses>> GetAllAddressesAsync()
        {
            return await dbContext.Addresses.ToListAsync();
        }

        public async Task<Addresses> RegisterAddressToCustomerAsync(Addresses addresses)
        {
            await dbContext.Addresses.AddAsync(addresses);
            await dbContext.SaveChangesAsync();
            return (addresses);
        }

        public async Task<Addresses?> UpdateAddressAsync(int id, Addresses addresses)
        {
            var existingAddress = await dbContext.Addresses.FirstOrDefaultAsync(x => x.AddressId == id);
            if (existingAddress == null)
            {
                return null;
            }
            existingAddress.City = addresses.City;
            existingAddress.Country = addresses.Country;
            existingAddress.Region = addresses.Region;
            existingAddress.PostalCode = addresses.PostalCode;
            await dbContext.SaveChangesAsync();
            return (existingAddress);
        }

    }
}
