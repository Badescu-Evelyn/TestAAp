using foodrecipe.Models;

using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;

namespace foodrecipe.Repository
{
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RecipeDbContext dbContext) : base(dbContext)
        {
        }
    }
}