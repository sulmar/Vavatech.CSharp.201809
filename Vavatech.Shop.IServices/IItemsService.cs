using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public interface IItemsService : IEntitiesService<Item>, 
        ISearchable<Item>
    {

        void AddRange(List<Item> items);
    }
}
