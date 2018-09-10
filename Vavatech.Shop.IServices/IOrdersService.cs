using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    // interfejs generyczny
    public interface IOrdersService : IEntitiesService<Order>
    {
        Order Get(string orderNumber);

    }
}
