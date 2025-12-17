using AutoMapper;
using foodrecipe.DataModels;
using foodrecipe.Models;



namespace foodrecipe.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Instruction, InstructionViewModel>().ReverseMap();
            CreateMap<Recipe, RecipeViewModel>().ReverseMap();
            CreateMap<Review, ReviewViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Ingredient, IngredientViewModel>().ReverseMap();
        }
    }
}