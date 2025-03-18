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

        public async Task<List<CustomerDetails>> GetAllCustomerAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10)
        {
            //var customerModel= await dbContext.CustomerDetails.Include(c=>c.Address).Include("ProductStatus").ToListAsync();
            var customerModel= dbContext.CustomerDetails.Include(c => c.Address).Include("ProductStatus").AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("CustomerName", StringComparison.OrdinalIgnoreCase))
                {
                    customerModel = customerModel.Where(x => x.CustomerName.Contains(filterQuery));
                }
            }

            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy)==false)
            {
                if (sortBy.Equals("CustomerName", StringComparison.OrdinalIgnoreCase))
                {
                    customerModel = isAscending ? customerModel.OrderBy(x => x.CustomerName) : customerModel.OrderByDescending(x => x.CustomerName);
                }
                else if (sortBy.Equals("PostalCode", StringComparison.OrdinalIgnoreCase))
                {
                    customerModel = isAscending ? customerModel.OrderBy(x => x.CustomerEmail) : customerModel.OrderByDescending(x => x.CustomerEmail);
                }
            }

            //Pagination
            var skipResults = (pageNumber - 1) * pageSize;
            return await customerModel.Skip(skipResults).Take(pageSize).ToListAsync();
            //return await customerModel.ToListAsync();
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
