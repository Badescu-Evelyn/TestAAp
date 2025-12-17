using foodrecipe.Models;

using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;

namespace foodrecipe.Repository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(RecipeDbContext dbContext) : base(dbContext)
        {
        }
    }
}