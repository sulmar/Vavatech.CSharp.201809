using System.Collections.Generic;

namespace Vavatech.Shop.IServices
{
    public interface IEntitiesService<TEntity>
    {
        List<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }

    public interface ISearchable<TEntity>
    {
        List<TEntity> Search(string arg);
    }
}
