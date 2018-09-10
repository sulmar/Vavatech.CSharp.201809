using System;
using System.Collections.Generic;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public class FakeCustomersService : ICustomersService
    {
        private List<Customer> customers;

        // ctor
        public FakeCustomersService()
        {
            customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Marcin",
                },

                new Customer
                {
                    Id = 2,
                    FirstName = "Bartek",
                    LastName = "Sulecki"
                },
            };

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
    }
}
