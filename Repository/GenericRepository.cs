using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;
using foodrecipe.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace foodrecipe.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly RecipeDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(RecipeDbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).AsNoTracking().ToListAsync();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Remove(entity);
        }

        public virtual IList<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression).ToList();
        }

        public virtual IList<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public virtual T? GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
        public Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public void DeleteRange(IList<T> entities)
        {
            foreach (var item in entities)
            {
                Delete(item);
            }
        }
        public Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}