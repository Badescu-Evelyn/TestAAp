using foodrecipe.Models;

namespace foodrecipe.DataModels
{
    public class Category 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Recipe> Recipes { get; set; } // One Category to Many Recipes
    }
}
