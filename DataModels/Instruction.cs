using foodrecipe.Models;

namespace foodrecipe.DataModels
{
    public class Instruction 
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
        public int? RecipeId { get; set; } // One Recipe to Many Instructions
        public Recipe Recipe { get; set; } // Navigation property
    }
}
