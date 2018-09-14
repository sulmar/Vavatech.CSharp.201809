using System;
using System.Collections.Generic;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using System.Linq;
using Bogus;
using Vavatech.Shop.Models.SearchCriteria;
using System.Threading.Tasks;

namespace Vavatech.Shop.FakeServices
{
    // Install-Package Bogus
    public class FakeCustomersService : ICustomersService
    {
        private List<Customer> customers;

        // ctor
        public FakeCustomersService()
        {
            var fakeAddresses = new Faker<Address>()
                .StrictMode(true)
                .Ignore(p => p.Id)
                .RuleFor(p => p.City, f => f.Address.City())
                .RuleFor(p => p.Country, f => f.Address.Country())
                .RuleFor(p => p.ZipCode, f => f.Address.ZipCode())
                .FinishWith((f, address) => Console.WriteLine($"Address was generated {address}"));

            var fakeCustomers = new Faker<Customer>()
               .StrictMode(true)
               .Ignore(p => p.Id)
               .RuleFor(p => p.FirstName, f => f.Person.FirstName)
               .RuleFor(p => p.LastName, f => f.Person.LastName)
               .RuleFor(p => p.VatNumber, f => f.Finance.Iban())
               .RuleFor(p => p.Salary, f => f.Finance.Amount())
               .RuleFor(p => p.WorkAddress, f => fakeAddresses)
               .RuleFor(p => p.HomeAddress, f => fakeAddresses)
               
               .FinishWith((f, customer) => Console.WriteLine($"Customer was created {customer}"));

            customers = fakeCustomers.Generate(100);
                

            //Customer customer1 = new Customer();
            //customer1.Id = 1;
            //customer1.FirstName = "Marcin";
            //customer1.LastName = "Sulecki";

            //Customer customer2 = new Customer
            //{
            //    Id = 2,
            //    FirstName = "Bartek",
            //    LastName = "Sulecki"
            //};

            //customers.Add(customer1);
            //customers.Add(customer2);
        }


        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public List<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer customer)
        {
            customers.Remove(customer);
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public decimal Calculate(Customer customer)
        {
            return 100;
        }

        public List<Customer> Search(string arg)
        {
            //List<Customer> results = new List<Customer>();

            //foreach (Customer customer in customers)
            //{
            //    if (customer.VatNumber.Contains(arg))
            //    {
            //        results.Add(customer);
            //    }
            //}

            //return results;

            return customers
                    .Where(c => c.VatNumber.Contains(arg))
                    .OrderBy(c => c.FirstName)
                    .ThenBy(c => c.LastName)
                    .Select(c => new Customer(c.Id, c.LastName.ToLower()))
                    .ToList();
            
        }

        public List<Customer> Search(CustomerSearchCriteria criteria)
        {
            IEnumerable<Customer> results = customers;

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

        public Task<List<Customer>> GetAsync()
        {
            return Task.Run(() => Get());
        }

        public Task<List<Customer>> SearchAsync(string arg)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
