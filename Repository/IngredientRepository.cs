using foodrecipe.Models;

using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;

namespace foodrecipe.Repository
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RecipeDbContext dbContext) : base(dbContext)
        {
        }
    }
}