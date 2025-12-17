using foodrecipe.DataModels;
using foodrecipe.Repository;
using foodrecipe.Repository.Interfaces;
using foodrecipe.Services.Interfaces;

namespace foodrecipe.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public RecipeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _repositoryWrapper.RecipeRepository.GetAllAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _repositoryWrapper.RecipeRepository.GetByIdAsync(id);
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            await _repositoryWrapper.RecipeRepository.AddAsync(recipe);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            await _repositoryWrapper.RecipeRepository.UpdateAsync(recipe);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _repositoryWrapper.RecipeRepository.GetByIdAsync(id);
            if (recipe != null)
            {
                await _repositoryWrapper.RecipeRepository.DeleteAsync(recipe);
                await _repositoryWrapper.SaveAsync();
            }
        }
    }
}
