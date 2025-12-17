using foodrecipe.DataModels;
using foodrecipe.Repository.Interfaces;
using foodrecipe.Services.Interfaces;

namespace foodrecipe.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        
        public ReviewService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _repositoryWrapper.ReviewRepository.GetAllAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _repositoryWrapper.ReviewRepository.GetByIdAsync(id);
        }

        public async Task AddReviewAsync(Review review)
        {
            await _repositoryWrapper.ReviewRepository.AddAsync(review);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdateReviewAsync(Review review)
        {
            await _repositoryWrapper.ReviewRepository.UpdateAsync(review);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _repositoryWrapper.ReviewRepository.GetByIdAsync(id);
            if (review != null)
            {
                await _repositoryWrapper.ReviewRepository.DeleteAsync(review);
                await _repositoryWrapper.SaveAsync();
            }
        }

        //public IEnumerable<Recipe> GetAllRecipes()
        //{
        //    return _repositoryWrapper.RecipeRepository.FindAll();
        //}

        //public IEnumerable<User> GetAllUsers()
        //{
        //    return _repositoryWrapper.UserRepository.FindAll();
        //}

    }
}
