namespace Teste.WebMvc.Services.Interfaces
{
    public interface IServiceBaseMVC<TEntity, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByIdAsync(TKey id);

        Task<TEntity> SaveAsync(TEntity dados);

        Task<TEntity> UpdateAsync(TEntity dados);

        Task<bool> DeleteAsync(TKey id);
    }
}
