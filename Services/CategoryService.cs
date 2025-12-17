using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;
using foodrecipe.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace foodrecipe.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            return await _repositoryWrapper.CategoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _repositoryWrapper.CategoryRepository.GetByIdAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _repositoryWrapper.CategoryRepository.AddAsync(category);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _repositoryWrapper.CategoryRepository.Update(category);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _repositoryWrapper.CategoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                await _repositoryWrapper.CategoryRepository.DeleteAsync(category);
                await _repositoryWrapper.SaveAsync();
            }
        }
    }
}
