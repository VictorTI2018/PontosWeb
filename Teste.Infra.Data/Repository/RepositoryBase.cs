using Microsoft.EntityFrameworkCore;
using Serilog;
using Teste.Core.Domain.Interfaces;
using Teste.Infra.Data.Context;

namespace Teste.Infra.Data.Repository
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        private readonly SqlContext _sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        

        public async Task<IEnumerable<TEntity>> GetAsync() => await _sqlContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(TKey id) => await _sqlContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> SaveAsync(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Add(obj);
                await _sqlContext.SaveChangesAsync();

                return obj;
            }catch(Exception ex)
            {
                Log.Information($"Ocorreu um erro ao criar a entidade {obj} - Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Update(obj);
                await _sqlContext.SaveChangesAsync();

                return obj;
            }
            catch (Exception ex)
            {
                Log.Information($"Ocorreu um erro ao atualizar a entidade {obj} - Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public  async Task<bool> DeleteAsync(TKey id)
        {
            try
            {
                TEntity obj = await GetByIdAsync(id);
                _sqlContext.Entry(obj).State = EntityState.Deleted;
                await _sqlContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Log.Information($"Ocorreu um erro ao deletar - Error: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
