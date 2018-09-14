using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    class TopItems
    {
        public Item Item { get; set; }
    }

    public class FakeItemsService : IItemsService
    {
        private List<Item> items;

        public FakeItemsService()
        {
            string[] colors = new string[] { "Red", "Blue", "Green" };

            var fakeProducts = new Faker<Product>()
               .StrictMode(true)
               .Ignore(p => p.Id)
               .RuleFor(p => p.Name, f => f.Commerce.ProductName())
               .RuleFor(p => p.Color, f => f.PickRandomParam(colors))
               .RuleFor(p => p.UnitPrice, f => f.Finance.Amount())
               .RuleFor(p => p.EAN, f => f.Finance.CreditCardNumber())
               ;

            var fakeServices = new Faker<Service>()
               .StrictMode(true)
               .Ignore(p => p.Id)
               .RuleFor(p => p.Name, f => f.Commerce.ProductName())
               .RuleFor(p => p.UnitPrice, f => f.Finance.Amount())
               .RuleFor(p => p.EAN, f => f.Finance.CreditCardNumber())
               ;

            var products = fakeProducts.Generate(100);
            var services = fakeServices.Generate(20);

            items = new List<Item>(products)
                .OfType<Item>()
                .Concat(services)
                .ToList();

            var fakeTopItems = new Faker<TopItems>()
                .RuleFor(p => p.Item, f => f.PickRandomParam(items.ToArray()));


            items = fakeTopItems.Generate(100).Select(p=>p.Item).ToList();

            //Random random = new Random();

            //for(int i=0; i<200; i++)
            //{
            //    if (0 == random.Next(0, 100) % 2)
            //    {
            //        items.Add(fakeProducts.Generate());
            //    }
            //    else
            //    {
            //        items.Add(fakeServices.Generate());
            //    }
            //}

            //items = products
            //    .OfType<Item>()
            //    .Concat(services)
            //    .ToList();

        }

        public void Add(Item item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<Item> items)
        {
            throw new NotImplementedException();
        }

        public List<Item> Get()
        {
            return items;
        }

        public Item Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Item item)
        {
            throw new NotImplementedException();
        }

        public List<Item> Search(string arg)
        {
            List<Item> results = new List<Item>();

            foreach (Item item in items)
            {
                if (item.EAN.Contains(arg))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public Task<List<Item>> SearchAsync(string arg)
        {
            throw new NotImplementedException();
        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
