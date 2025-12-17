namespace foodrecipe.Models
{
    public class InstructionViewModel
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; internal set; }

    }
}