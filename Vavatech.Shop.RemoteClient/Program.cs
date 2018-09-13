using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.RemoteClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Hello World!");

            // Thread.Sleep(TimeSpan.FromSeconds(3));

            //AddCustomerTest();

            //GetCustomersTest();

            // Synchroniczna
            //DoWork();

            //DoWork();

            // Asynchroniczna
            //DoWorkAsync();

            //DoWorkAsync();

            // Synchroniczna
            decimal result = Calculate(100);
            result = Calculate(result);
            result = Calculate(result);


            // Asynchroniczna
            Task.Run<decimal>(() =>
                Calculate(100))
                    .ContinueWith(t => Calculate(t.Result))
                        .ContinueWith(t => Calculate(t.Result));




       

            //for (int i = 0; i < 100; i++)
            //{
            //    Task.Run(() => DoWork());
            //}


            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Press any key to exit.");

            Console.ReadKey();
        }

        private static Task DoWorkAsync()
        {
            return Task.Run(() => DoWork());
        }

        private static decimal Calculate(decimal amount)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calcuting...");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculated. {++amount}");

            return amount;
        }

        private static void DoWork()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Downloading...");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Downloaded.");
        }

        private static void AddCustomerTest()
        {
            Customer customer = new Customer
            {
                FirstName = "John",
                LastName = "Smith",
                HomeAddress = new Address
                {
                    City = "Warsaw",
                    Country = "Poland",
                    ZipCode = "01466"

                }
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44393");

            HttpResponseMessage response = 
                client.PostAsync<Customer>("api/customers", customer, new JsonMediaTypeFormatter()).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Utworzono");
            }
        }


        static void GetCustomersTest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44393");

            HttpResponseMessage response = client.GetAsync("api/customers").Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(json);

                // Install-Package Microsoft.AspNet.WebApi.Client

                var customers = response.Content.ReadAsAsync<List<Customer>>().Result;

                
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
                
            }

        }
    }
}
