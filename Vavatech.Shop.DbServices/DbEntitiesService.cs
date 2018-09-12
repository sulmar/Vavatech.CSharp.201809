using System.Collections.Generic;
using System.Linq;
using Vavatech.Shop.IServices;

namespace Vavatech.Shop.DbServices
{
    public class DbEntitiesService<TEntity> : IEntitiesService<TEntity>
        where TEntity : class
    {
        private readonly ShopContext context;

        public DbEntitiesService(ShopContext context)
        {
            this.context = context;
        }

        public virtual void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public virtual List<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
