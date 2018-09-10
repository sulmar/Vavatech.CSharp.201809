using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public class FakeItemsService : IItemsService
    {
        private List<Item> items = new List<Item>
        {
            new Product(name:"Keyboard", color:"Black", unitPrice: 100 ),
            new Service("Printing", 10),
        };

        public void Add(Item item)
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

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
