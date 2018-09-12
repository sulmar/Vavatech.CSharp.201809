using System;
using System.Collections.Generic;
using Vavatech.Shop.Models;
using Vavatech.Shop.Models.SearchCriteria;

namespace Vavatech.Shop.IServices
{
    public interface ICustomersService : IEntitiesService<Customer>, 
        ISearchable<Customer>
    {
        List<Customer> Search(CustomerSearchCriteria criteria);
    }


}
