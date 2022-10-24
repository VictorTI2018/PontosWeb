

namespace Teste.Core.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByIdAsync(TKey id);

        Task<TEntity> SaveAsync(TEntity obj);

        Task<TEntity> UpdateAsync(TEntity obj);

        Task<bool> DeleteAsync(TKey id);
    }
}
