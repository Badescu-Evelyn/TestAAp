using foodrecipe.Repository.Interfaces;
using foodrecipe.Repository;
using Microsoft.EntityFrameworkCore;

namespace foodrecipe.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly RecipeDbContext _recipeDbContext;
    private ICategoryRepository? _categoryRepository;
    private IIngredientRepository? _ingredientRepository;
    private IInstructionRepository? _instructionRepository;
    private IRecipeRepository? _recipeRepository;
    private IUserRepository? _userRepository;
    private IReviewRepository? _reviewRepository;

    public ICategoryRepository CategoryRepository
    {
        get
        {
            if (_categoryRepository == null)
            {
                _categoryRepository = new CategoryRepository(_recipeDbContext);
            }

            return _categoryRepository;
        }
    }

    public IIngredientRepository IngredientRepository
    {
        get
        {
            if (_ingredientRepository == null)
            {
                _ingredientRepository = new IngredientRepository(_recipeDbContext);
            }

            return _ingredientRepository;
        }
    }

    public IInstructionRepository InstructionRepository
    {
        get
        {
            if (_instructionRepository == null)
            {
                _instructionRepository = new InstructionRepository(_recipeDbContext);
            }

            return _instructionRepository;
        }
    }

    public IReviewRepository ReviewRepository
    {
        get
        {
            if (_reviewRepository == null)
            {
                _reviewRepository = new ReviewRepository(_recipeDbContext);
            }

            return _reviewRepository;
        }
    }

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_recipeDbContext);
            }

            return _userRepository;
        }
    }
    public IRecipeRepository RecipeRepository
    {
        get
        {
            if (_recipeRepository == null)
            {
                _recipeRepository = new RecipeRepository(_recipeDbContext);
            }

            return _recipeRepository;
        }
    }

    public RepositoryWrapper(RecipeDbContext recipeDbContext)
    {
        _recipeDbContext = recipeDbContext;
    }

    public void Save()
    {
        _recipeDbContext.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _recipeDbContext.SaveChangesAsync();
    }
}