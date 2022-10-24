using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Core.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByIdAsync(TKey id);

        Task<TEntity> SaveAsync(TEntity obj);
    }
}
