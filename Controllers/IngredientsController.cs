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
    public class IngredientsController : Controller
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var ingredients = await _ingredientService.GetAllIngredientsAsync();
            return View(ingredients);
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _ingredientService.GetIngredientByIdAsync(id.Value);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientViewModel ingredientViewModel)
        {
            if (ModelState.IsValid)
            {
                // Map ViewModel to Domain Model
                var ingredient = new Ingredient
                {
                    Id = ingredientViewModel.Id,
                    Name = ingredientViewModel.Name,
                    Quantity = ingredientViewModel.Quantity,
                    //RecipeId = ingredientViewModel.RecipeId
                };

                await _ingredientService.AddIngredientAsync(ingredient);
                return RedirectToAction(nameof(Index));
            }
            return View(ingredientViewModel);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _ingredientService.GetIngredientByIdAsync(id.Value);
            if (ingredient == null)
            {
                return NotFound();
            }

            var editViewModel = new IngredientViewModel
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
                //RecipeId = ingredient.RecipeId
            };

            return View(editViewModel);
        }

        // POST: Ingredients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IngredientViewModel editViewModel)
        {
            if (id != editViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ingredient = new Ingredient
                    {
                        Id = editViewModel.Id,
                        Name = editViewModel.Name,
                        Quantity = editViewModel.Quantity,
                       // RecipeId = editViewModel.RecipeId
                    };
                    await _ingredientService.UpdateIngredientAsync(ingredient);
                }
                catch (Exception)
                {
                    if (!await IngredientExists(editViewModel.Id))
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
        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _ingredientService.GetIngredientByIdAsync(id.Value);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
            if (ingredient != null)
            {
                await _ingredientService.DeleteIngredientAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IngredientExists(int id)
        {
            var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
            return ingredient != null;
        }
    }
}
