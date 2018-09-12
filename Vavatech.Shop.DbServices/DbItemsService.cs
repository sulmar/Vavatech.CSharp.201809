using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.DbServices
{

    public class DbItemsService : DbEntitiesService<Item>, IItemsService, ISearchable<Item>
    {
        public DbItemsService(ShopContext context) : base(context)
        {
        }

        public List<Item> Search(string arg)
        {
            throw new NotImplementedException();
        }


        public void AddRange(List<Item> items)
        {
            context.AddRange(items);
            context.SaveChanges();
        }
    }
}
