using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;
using foodrecipe.Services.Interfaces;

namespace foodrecipe.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public IngredientService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await _repositoryWrapper.IngredientRepository.GetAllAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            return await _repositoryWrapper.IngredientRepository.GetByIdAsync(id);
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            await _repositoryWrapper.IngredientRepository.AddAsync(ingredient);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            await _repositoryWrapper.IngredientRepository.UpdateAsync(ingredient);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteIngredientAsync(int id)
        {
            var ingredient = await _repositoryWrapper.IngredientRepository.GetByIdAsync(id);
            if (ingredient != null)
            {
                await _repositoryWrapper.IngredientRepository.DeleteAsync(ingredient);
                await _repositoryWrapper.SaveAsync();
            }
        }
    }
}
