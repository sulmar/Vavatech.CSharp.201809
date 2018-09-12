using Vavatech.Shop.Models;

namespace Vavatech.Shop.DbServices
{
    public class DbOrdersService : DbEntitiesService<Order>
    {
        public DbOrdersService(ShopContext context)
            : base(context)
        {
        }


        public override void Remove(Order entity)
        {
            base.Remove(entity);
        }
    }
}
