﻿using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.Extensions;
using static System.Console;
using Vavatech.Shop.Models.SearchCriteria;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Vavatech.Shop.DbServices;
using Microsoft.EntityFrameworkCore;

namespace Vavatech.Shop.ConsoleClient
{
   


    class Program
    {
        // Wygenerowanie exe
        // dotnet build -r win10-x64

        static void SendSms(string message)
        {
            Console.WriteLine($"Send sms {message}");
        }

        static void SendFacebook(string post)
        {
            Console.WriteLine($"Send post {post}");
        }

        static void SendTweet(string tweet)
        {
            Console.WriteLine(tweet);
        }

        static void SendInstagram(byte[] photo)
        {

        }

        public delegate void Send(string message);


        static void Main(string[] args)
        {
            WriteLine("Hello World!");

            // Install-Package Microsoft.Extensions.Configuration
            // Install-Package Microsoft.Extensions.Configuration.FileExtensions
            // Install-Package Microsoft.Extensions.Configuration.Json
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            WriteLine(configuration.GetConnectionString("ShopConnection"));

            // Install-Package Microsoft.Extensions.DependencyInjection
            ServiceCollection services = new ServiceCollection();
            services.AddTransient<ICustomersService, DbCustomersService>();
            services.AddTransient<IItemsService, DbItemsService>();

            // Install-Package Microsoft.EntityFrameworkCore.SqlServer
            services.AddDbContext<ShopContext>(options => options
                        .UseSqlServer(configuration.GetConnectionString("ShopConnection")));

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            // ICustomersService customersService = new FakeCustomersService();
            ICustomersService customersService = serviceProvider.GetService<ICustomersService>();

            var query = customersService.Get();

           
            var items = new FakeItemsService().Get();
            IItemsService itemsService = serviceProvider.GetService<IItemsService>();
            itemsService.AddRange(items);

            var customers = customersService.Search(new CustomerSearchCriteria { Country = "Poland" });

            var newCustomers = new FakeCustomersService().Get();

            foreach (var newCustomer in newCustomers)
            {
                customersService.Add(newCustomer);
            }


            LinqTest(customersService);


            // Uwaga: W przypadku float/double mimo dzielenia przez zero nie pojawi się błąd, 
            // lecz przyjmie wartość infinity!
            double result = 2d / 0;
            Console.WriteLine(result);

            // DelegateTest();

            // Typ anonimowy
            // AnonymouseTypeTest();

            Customer customer = GetCustomer();

            var order = new Order(customer);

            Item item;

            do
            {
                item = GetItem();
                int quantity = GetQuantity();

                OrderDetail detail = new OrderDetail(item, quantity);

                order.AddDetail(detail);


            } while (item != null);

            // EnumTest(order);

            // ExtensionsMethodTest();

             GetCustomersTest();

            // GetItemsTest();

            #region Variable vs Reference Types

            VariableTest();
            StringTest();
            ReferenceTest();

            #endregion


            Helper.GreaterThanZero(100);

        }

        private static void EnumTest(Order order)
        {
            order.RoomStatus = RoomStatus.L1 | RoomStatus.O | RoomStatus.P;

            if (order.RoomStatus.HasFlag(RoomStatus.P))
            {
                WriteLine("Display screen");
            }

            if (order.Status == OrderStatus.Sent)
            {
            }
        }

        private static void LinqTest(ICustomersService customersService)
        {
            var customers = customersService.Get();

            var query = customers.GroupBy(c => c.FirstName)
                    .Select(g => new { FirstName = g.Key, Qty = g });
        }

        private static void AnonymouseTypeTest()
        {
            var user = new
            {
                FirstName = "Marcin",
                IsRemoved = false,
                Salary = 1000.99m,
            };
        }

        private static void DelegateTest()
        {
            Send send = SendSms;
            send += SendFacebook;
            send += SendTweet;

           
            // metoda anonimowa
            send += delegate (string msg)
            {
                Console.WriteLine($"Logger {msg}");
            };


            // Wyrażenie lambda
            send += msg => Console.WriteLine($"Logger 2 {msg}");

            // send += SendInstagram;

            // Dobra praktyka - przed wywołaniem sprawdź czy nie jest null
            if (send != null)
            {
                send("Hello");
            }

            send -= SendSms;

            send = null;

            send?.Invoke("World");
        }

        private static int GetQuantity()
        {
            Write("Podaj ilość: ");

            return int.Parse(ReadLine());
        }

        private static Item GetItem()
        {
            Write("Podaj kod: ");

            string ean = ReadLine();

            IItemsService itemsService = new FakeItemsService();
            List<Item> items = itemsService.Search(ean);

            if (items.Any())
            {
                foreach (Item item in items)
                {
                    WriteLine($"{items.IndexOf(item) + 1} \t- {item}");
                }

                Write("Podaj indeks");

                if (int.TryParse(ReadLine(), out int index))
                {
                    return items[index - 1];
                }
                else
                {
                    Write("Błędna wartość");
                }

            }

            return null;

        }

        private static Customer GetCustomer()
        {
            Write("Podaj NIP: ");
            string vatNumber = ReadLine();

            ICustomersService customersService = new FakeCustomersService();
            List<Customer> customers = customersService.Search(vatNumber);

            if (customers.Any())
            {
                WriteLine($"Znaleziono {customers.Count}");


                //foreach (Customer customer in customers)
                //{
                //    WriteLine($"{customers.IndexOf(customer)+1} \t- {customer}");
                //}

                customers.ForEach(customer => WriteLine($"{customers.IndexOf(customer) + 1} \t- {customer}"));

                Write("Podaj indeks");

                if (int.TryParse(ReadLine(), out int index))
                {
                    return customers[index-1];
                }
                else
                {
                    Write("Błędna wartość");
                }
            }
            else
            {
                WriteLine("Nie znaleziono");
            }


            return null;
        }

        private static void StringTest()
        {
            string message = "Hello World";

            Calculate(message);
        }

        private static void ReferenceTest()
        {
            Customer customer1 = new Customer();
            customer1.Salary = 10;

            Calculate(customer1);
        }

        private static void VariableTest()
        {
            int x = 10;

            Calculate(x);
        }

        private static void ExtensionsMethodTest()
        {
            bool canShopping = DateTime.Today.CanShopping();
        }

        private static void GetItemsTest()
        {
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
        }

        private static void GetCustomersTest()
        {
            ICustomersService customersService = new FakeCustomersService();

            List<Customer> customers = customersService.Get();

            // snippet: foreach
            foreach (Customer customer in customers)
            {
                // snippet: cw
                Console.WriteLine(customer);

                // customersService.Calculate(customer);
            }
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
