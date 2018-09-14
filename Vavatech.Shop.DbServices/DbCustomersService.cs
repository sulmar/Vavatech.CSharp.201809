using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.Models.SearchCriteria;

namespace Vavatech.Shop.DbServices
{
    // Install-Package Microsoft.EntityFrameworkCore
    public class DbCustomersService : ICustomersService
    {
        private readonly ShopContext context;

        public DbCustomersService(ShopContext context)
        {
            this.context = context;
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);

            Console.WriteLine(context.Entry(customer).State);

            context.SaveChanges();
        }

        public async Task AddAsync(Customer entity)
        {
            await context.Customers.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public List<Customer> Get()
        {
            return context.Customers
                .Include(p=>p.WorkAddress)  // Eager loading
                .Include(p=>p.HomeAddress)
                .ToList();
        }

        public Customer Get(int id)
        {
            return context.Customers.Find(id);
        }

        public Task<List<Customer>> GetAsync()
        {
            return context.Customers.ToListAsync();
        }

        public Task<Customer> GetAsync(int id)
        {
            return context.Customers.FindAsync(id);
        }

        public void Remove(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public async Task RemoveAsync(Customer entity)
        {
            context.Customers.Remove(entity);
            await context.SaveChangesAsync();
        }

        public List<Customer> Search(string arg)
        {
            return context.Customers
                .Where(c => c.VatNumber.Contains(arg))
                .ToList();
        }

        public List<Customer> Search(CustomerSearchCriteria criteria)
        {
            IEnumerable<Customer> results = context.Customers;

            if (!string.IsNullOrEmpty(criteria.Country))
            {
                results = results.Where(c => c.HomeAddress?.Country == criteria.Country);
            }

            if (!string.IsNullOrEmpty(criteria.City))
            {
                results = results.Where(c => c.HomeAddress?.City == criteria.City);
            }

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                results = results.Where(c => c.FirstName == criteria.Name);
            }

            return results.ToList();
        }

        public async Task<List<Customer>> SearchAsync(string arg)
        {
             return await context.Customers
                .Where(c => c.VatNumber.Contains(arg))
                .ToListAsync();
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }

        public async Task UpdateAsync(Customer entity)
        {
            context.Customers.Update(entity);
            await context.SaveChangesAsync();
        }

      
    }
}
