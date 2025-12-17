using foodrecipe.DataModels;
using foodrecipe.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace foodrecipe.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);

    }
}
