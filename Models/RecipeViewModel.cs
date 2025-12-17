namespace foodrecipe.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string ImageUrl { get; set; }
        
    }
}