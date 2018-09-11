using System;
using System.Text;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public interface IItemsService : IEntitiesService<Item>, 
        ISearchable<Item>
    {
    }
}
