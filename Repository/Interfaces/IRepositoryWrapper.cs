namespace foodrecipe.Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository CategoryRepository { get; }
        IIngredientRepository IngredientRepository { get; }
        IInstructionRepository InstructionRepository { get; }
        IRecipeRepository RecipeRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IUserRepository UserRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
