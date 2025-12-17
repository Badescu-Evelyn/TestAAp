using foodrecipe.Models;

using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;

namespace foodrecipe.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(RecipeDbContext dbContext) : base(dbContext)
        {
        }
    }
}