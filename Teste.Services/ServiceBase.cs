using Teste.Core.Domain.Interfaces;
using Teste.Core.Domain.Interfaces.Services;

namespace Teste.Services
{
    public class ServiceBase<TEntity, TKey> : IServiceBase<TEntity, TKey> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity, TKey> _repoBase;

        public ServiceBase(IRepositoryBase<TEntity, TKey> repoBase)
        {
            _repoBase = repoBase;
        }

        public async Task<IEnumerable<TEntity>> GetAsync() => await _repoBase.GetAsync();

        public async Task<TEntity> GetByIdAsync(TKey id) => await _repoBase.GetByIdAsync(id);

        public async Task<TEntity> SaveAsync(TEntity obj)
        {
            return await _repoBase.SaveAsync(obj);
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            return await _repoBase.UpdateAsync(obj);
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            return await _repoBase.DeleteAsync(id);
        }
    }
}
