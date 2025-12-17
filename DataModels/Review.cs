using foodrecipe.Models;

namespace foodrecipe.DataModels
{
    public class Review 
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int? RecipeId { get; set; } // One Recipe to Many Reviews
        public Recipe Recipe { get; set; } // Navigation property
        // Foreign Key
        public string? UserId { get; set; }
        // Navigation property
        public User User { get; set; }
    }
}
