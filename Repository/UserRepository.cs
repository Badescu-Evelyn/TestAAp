using foodrecipe.Models;

using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;

namespace foodrecipe.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(RecipeDbContext dbContext) : base(dbContext)
        {
        }
    }
}