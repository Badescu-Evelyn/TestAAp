using foodrecipe.Models;

namespace foodrecipe.DataModels
{
    public class Recipe 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; } // One Category to Many Recipes
        public Category Category { get; set; } // Navigation property

        public ICollection<Ingredient> Ingredients { get; set; } // one Ingredients to Many Recipes
        public ICollection<Instruction> Instructions { get; set; } // One Recipe to Many Instructions
        public ICollection<Review> Reviews { get; set; } // One Recipe to Many Reviews
    }
}
