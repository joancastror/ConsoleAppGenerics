

using ConsoleAppGenerics.Class;
using ConsoleAppGenerics.Interfaces;
using ConsoleAppGenerics.Models;
using System.Linq.Expressions;
using System.Linq;

namespace ConsoleAppGenerics.Objects
{
    public class CustomerDb : IBaseRepository<Customer, CustomerResult, List<CustomerResult>>
    {
        private readonly List<Customer> customers;

        public CustomerDb(List<Customer> customers)
        {
            this.customers = customers;

        }

        public async Task<bool> Exists(Func<Customer, bool> filter)
        {
            var result = this.customers.Any(filter);

            return await Task.FromResult(result);
        }

        public async Task<List<CustomerResult>> GetAll()
        {
            List<CustomerResult> customerResults = new List<CustomerResult>();

            customerResults = this.customers.Select(cd => new CustomerResult()
            {
                Address = cd.Address,
                Id = cd.Id,
                Name = string.Concat(cd.FirtName, " ", cd.LastName),
                Phone = cd.Phone,
            }).ToList();

            return await Task.FromResult<List<CustomerResult>>(customerResults);
        }

        public async Task<List<CustomerResult>> GetAll(Func<Customer, bool> filter)
        {
            List<CustomerResult> customerResults = new List<CustomerResult>();

            customerResults = this.customers.Where(filter).Select(cd => new CustomerResult()
            {
                Address = cd.Address,
                Id = cd.Id,
                Name = string.Concat(cd.FirtName, " ", cd.LastName),
                Phone = cd.Phone,
            }).ToList();

            return await Task.FromResult<List<CustomerResult>>(customerResults);
        }

        public async Task<CustomerResult> GetEntityBy(int Id)
        {
            CustomerResult customerResult = new CustomerResult();

            var customer = this.customers.FirstOrDefault(cd => cd.Id == Id);

            customerResult.Id = customer.Id;
            customerResult.Name = string.Concat(customer.FirtName, " ", customer.LastName);
            customerResult.Phone = customer.Phone;
            customerResult.Address = customer.Address;

            return await Task.FromResult<CustomerResult>(customerResult);
        }

        public async Task<CustomerResult> Remove(Customer entity)
        {
            CustomerResult customerResult = new CustomerResult();

            var customer = this.customers.FirstOrDefault(cd => cd.Id == entity.Id);

            this.customers.Remove(customer);

            return await Task.FromResult(customerResult);

        }

        public async Task<CustomerResult> Save(Customer entity)
        {
            CustomerResult customerResult = new CustomerResult();

            this.customers.Add(entity);

            return await Task.FromResult(customerResult);

        }

        public async Task<CustomerResult> Update(Customer entity)
        {
            CustomerResult customerResult = new CustomerResult();

            await this.Remove(entity);

            await this.Save(entity);

            return await Task.FromResult(customerResult);
        }
    }
}
