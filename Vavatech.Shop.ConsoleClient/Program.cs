using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.Extensions;

namespace Vavatech.Shop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            bool canShopping = DateTime.Today.CanShopping();


            Console.WriteLine("Hello World!");

            ICustomersService customersService = new FakeCustomersService();

            List<Customer> customers = customersService.Get();

            // snippet: foreach
            foreach (Customer customer in customers)
            {
                // snippet: cw
                Console.WriteLine(customer);

                // customersService.Calculate(customer);
            }


            IItemsService itemsService = new FakeItemsService();

            List<Item> items = itemsService.Get();

            List<Product> products = items.OfType<Product>().ToList();

            foreach (Item item in items)
            {
                Console.WriteLine(item);

                item.Print();
            }

            foreach (Product product in products)
            {
                product.Print();
            }

            IOrdersService ordersService; // = ...;


            int x = 10;

            Calculate(x);


            Customer customer1 = new Customer();
            customer1.Salary = 10;

            Calculate(customer1);

            string message = "Hello World";

            Calculate(message);

            Helper.GreaterThanZero(100);

            //Product product = new Models.Product();
        }


        static void Calculate(string message)
        {
            message = "Hello 2";
        }

        static void Calculate(int x)
        {
            x++;
        }

        static void Calculate(Customer customer)
        {
            customer.Salary++;
        }
    }
}
