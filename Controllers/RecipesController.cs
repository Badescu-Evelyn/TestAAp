using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using foodrecipe.DataModels;
using foodrecipe.Services.Interfaces;
using foodrecipe.Models;
using Microsoft.AspNetCore.Authorization;

namespace foodrecipe.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return View(recipes);
        }
        // GET: Categories/CustomView
        public IActionResult Categories()
        {
            return View("Recipes");
        }
        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _recipeService.GetRecipeByIdAsync(id.Value);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                var recipe = new Recipe
                {
                    Id = recipeViewModel.Id,
                    Name = recipeViewModel.Name,
                    Description = recipeViewModel.Description,
                    PreparationTime = recipeViewModel.PreparationTime,
                    CookingTime = recipeViewModel.CookingTime,
                    DifficultyLevel = recipeViewModel.DifficultyLevel,
                    ImageUrl = recipeViewModel.ImageUrl,
                 //   CategoryId = recipeViewModel.CategoryId
                };

                await _recipeService.AddRecipeAsync(recipe);
                return RedirectToAction(nameof(Index));
            }
            return View(recipeViewModel);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _recipeService.GetRecipeByIdAsync(id.Value);
            if (recipe == null)
            {
                return NotFound();
            }

            var editViewModel = new RecipeViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                PreparationTime = recipe.PreparationTime,
                CookingTime = recipe.CookingTime,
                DifficultyLevel = recipe.DifficultyLevel,
                ImageUrl = recipe.ImageUrl,
               // CategoryId = recipe.CategoryId
            };

            return View(editViewModel);
        }

        // POST: Recipes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RecipeViewModel editViewModel)
        {
            if (id != editViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var recipe = new Recipe
                    {
                        Id = editViewModel.Id,
                        Name = editViewModel.Name,
                        Description = editViewModel.Description,
                        PreparationTime = editViewModel.PreparationTime,
                        CookingTime = editViewModel.CookingTime,
                        DifficultyLevel = editViewModel.DifficultyLevel,
                        ImageUrl = editViewModel.ImageUrl,
                     //   CategoryId = editViewModel.CategoryId
                    };
                    await _recipeService.UpdateRecipeAsync(recipe);
                }
                catch (Exception)
                {
                    if (!await RecipeExists(editViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editViewModel);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _recipeService.GetRecipeByIdAsync(id.Value);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe != null)
            {
                await _recipeService.DeleteRecipeAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RecipeExists(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            return recipe != null;
        }
    }
}
