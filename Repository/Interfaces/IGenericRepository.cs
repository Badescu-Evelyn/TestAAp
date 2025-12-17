using System.Linq.Expressions;

namespace foodrecipe.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        IList<T> GetAll();
        Task UpdateAsync(T entity);

        T? GetById(int id);

        void Update(T entity);

        void Delete(T entity);
        Task DeleteAsync(T entity);
        IList<T> Get(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void Save();

        void DeleteRange(IList<T> entities);
        Task SaveAsync();
    }
}