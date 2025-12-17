using foodrecipe.DataModels;

namespace foodrecipe.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task AddReviewAsync(Review review);
        Task UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(int id);
        //IEnumerable<Recipe> GetAllRecipes();
        //IEnumerable<User> GetAllUsers();
    }
}
