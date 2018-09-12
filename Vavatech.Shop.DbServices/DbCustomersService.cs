using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Customer> Get()
        {
            return context.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return context.Customers.Find(id);
        }

        public void Remove(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
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
                results = results.Where(c => c.HomeAddress.Country == criteria.Country);
            }

            if (!string.IsNullOrEmpty(criteria.City))
            {
                results = results.Where(c => c.HomeAddress.City == criteria.City);
            }

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                results = results.Where(c => c.FirstName == criteria.Name);
            }

            return results.ToList();
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }
}
