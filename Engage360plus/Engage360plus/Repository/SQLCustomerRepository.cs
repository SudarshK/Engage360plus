using Engage360plus.Data;
using Engage360plus.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Engage360plus.Repository
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly CRMDbContext dbContext;

        public SQLCustomerRepository(CRMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CustomerDetails>> GetAllCustomerAsync()
        {
            var customerModel= await dbContext.CustomerDetails.Include(c=>c.Address).Include("ProductStatus").ToListAsync();
            return customerModel;
        }

        public async Task<CustomerDetails?> GetCustomerByIdAsync(Guid id)
        {
            var customerModel = await dbContext.CustomerDetails.Include(c=>c.Address)
                .Include("ProductStatus")
                .FirstOrDefaultAsync(x => x.Id == id);
            return customerModel;
        }

        public async Task<CustomerDetails> RegisterCustomerAsync(CustomerDetails customerDetails)
        {
            await dbContext.CustomerDetails.AddAsync(customerDetails);
            await dbContext.SaveChangesAsync();
            return customerDetails;
        }

        public async Task<CustomerDetails?> UpdateAsync(Guid id, CustomerDetails customerDetails)
        {
            var existingCustomer= await dbContext.CustomerDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCustomer == null)
            {
                return null;
            }
            existingCustomer.CustomerName = customerDetails.CustomerName;
            existingCustomer.CustomerEmail = customerDetails.CustomerEmail;
            existingCustomer.AddressId = customerDetails.AddressId;
            existingCustomer.ProductStatusId = customerDetails.ProductStatusId;
            await dbContext.SaveChangesAsync();
            return existingCustomer;
        }
    }
}
