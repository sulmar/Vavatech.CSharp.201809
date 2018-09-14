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
        static CancellationTokenSource cancellationTokenSource;

        static async Task Main(string[] args)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Hello World!");

            DisposableTest();

            // Thread.Sleep(TimeSpan.FromSeconds(3));

            //AddCustomerTest();

            // GetCustomersTest();

            Task task1 = GetCustomersAsyncTest();
            Task task2 = GetCustomersAsyncTest();
            Task task3 = GetCustomersAsyncTest();

            List<Task> tasks = new List<Task>();
            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);

            await Task.WhenAll(tasks);


            Console.WriteLine("continue...");

            // task1.Wait();

            // Synchroniczna
            //DoWork();

            //DoWork();

            // Asynchroniczna
            //DoWorkAsync();

            //DoWorkAsync();

            // Synchroniczna
            // SyncTest();


            // Asynchroniczna
            // TaskTest();

            // AsyncAwaitTest();

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Press Enter key to exit.");

            Console.ReadLine();

        }

        private static void DisposableTest()
        {
            Printer printer = new Printer();

            try
            {
                printer.Print("Hello World");
            }
            catch (Exception e)
            {
            }

            finally
            {
                printer.Dispose();
            }


            //Printer printer2 = new Printer();
            //printer2.Dispose();
            //printer2.Print("Hello");

            try
            {
                using (Printer printer3 = new Printer())
                {
                    printer3.Print("Hello");
                }

            }
            catch (Exception e)
            {

            }
        }

        private static void AsyncAwaitTest()
        {
            cancellationTokenSource = new CancellationTokenSource();

            CancellationToken token = cancellationTokenSource.Token;

            // cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(1));

            Progress<int> progress = new Progress<int>();

            progress.ProgressChanged += Progress_ProgressChanged;

            Console.CancelKeyPress += Console_CancelKeyPress;

            try
            {
                AsyncTest(token, progress);

                Console.ReadKey();

                cancellationTokenSource.Cancel();

                Console.ReadKey();
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        private static void Progress_ProgressChanged(object sender, int e)
        {
            Console.WriteLine($"===> Step {e}");
        }

        //private static void SyncTest()
        //{
        //    decimal result = Calculate(100);
        //    result = Calculate(result);
        //    result = Calculate(result);
        //}

        //private static void TaskTest()
        //{
        //    CalculateAsync(100)
        //            .ContinueWith(t => Calculate(t.Result))
        //                    .ContinueWith(t => Calculate(t.Result));
        //}

        private static async Task AsyncTest(CancellationToken token, IProgress<int> progress)
        {
            try
            {
                decimal result = await CalculateAsync(100, token, progress);
                result = await CalculateAsync(result, token, progress);
                result = await CalculateAsync(result, token, progress);
            }
            catch
            {
                throw;
            }
        }


        private static Task<decimal> CalculateAsync(decimal amount, CancellationToken token, IProgress<int> progress)
        {
            return Task<decimal>.Run(() => Calculate(amount, token, progress));
        }

        private static Task DoWorkAsync()
        {
            return Task.Run(() => DoWork());
        }

        private static decimal Calculate(decimal amount, CancellationToken token, IProgress<int> progress)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calcuting...");

            for (int i = 0; i < 10; i++)
            {
               //  token.ThrowIfCancellationRequested();

                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }

                //if (token.IsCancellationRequested)
                //{
                    

                //    // break;
                //}

                // Console.WriteLine($"Step {i}");

                progress.Report(i);

                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            

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


        static async Task GetCustomersAsyncTest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44393");

            HttpResponseMessage response = await client.GetAsync("api/customers");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

                // Install-Package Microsoft.AspNet.WebApi.Client

                var customers = await response.Content.ReadAsAsync<List<Customer>>();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }

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
