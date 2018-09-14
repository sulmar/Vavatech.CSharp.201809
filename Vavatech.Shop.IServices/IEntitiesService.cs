using System.Collections.Generic;
using System.Threading.Tasks;

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

    public interface IEntitiesServiceAsync<TEntity>
    {
        Task<List<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }

    public interface ISearchable<TEntity>
    {
        List<TEntity> Search(string arg);
        Task<List<TEntity>> SearchAsync(string arg);
    }

}
