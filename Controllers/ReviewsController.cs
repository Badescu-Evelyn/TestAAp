using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using foodrecipe.Services.Interfaces;
using foodrecipe.Models;
using foodrecipe.DataModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace foodrecipe.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return View(reviews);
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviewService.GetReviewByIdAsync(id.Value);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
          //  ViewData["RecipeId"] = new SelectList(_reviewService.GetAllRecipes(), "Id", "Name");
           // ViewData["UserId"] = new SelectList(_reviewService.GetAllUsers(), "Id", "UserName");
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewViewModel reviewViewModel)
        {
            if (ModelState.IsValid)
            {
                var review = new Review
                {
                    Rating = reviewViewModel.Rating,
                    Comment = reviewViewModel.Comment,
                    Date = reviewViewModel.Date,
                   // RecipeId = reviewViewModel.RecipeId,
                   // UserId = reviewViewModel.UserId
                };

                await _reviewService.AddReviewAsync(review);
                return RedirectToAction(nameof(Index));
            }
           // ViewData["RecipeId"] = new SelectList(_reviewService.GetAllRecipes(), "Id", "Name", reviewViewModel.RecipeId);
            //ViewData["UserId"] = new SelectList(_reviewService.GetAllUsers(), "Id", "UserName", reviewViewModel.UserId);
            return View(reviewViewModel);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviewService.GetReviewByIdAsync(id.Value);
            if (review == null)
            {
                return NotFound();
            }

            var editViewModel = new ReviewViewModel
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment,
                Date = review.Date,
               // RecipeId = review.RecipeId,
              //  UserId = review.UserId
            };

           // ViewData["RecipeId"] = new SelectList(_reviewService.GetAllRecipes(), "Id", "Name", editViewModel.RecipeId);
           // ViewData["UserId"] = new SelectList(_reviewService.GetAllUsers(), "Id", "UserName", editViewModel.UserId);
            return View(editViewModel);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReviewViewModel editViewModel)
        {
            if (id != editViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var review = new Review
                    {
                        Id = editViewModel.Id,
                        Rating = editViewModel.Rating,
                        Comment = editViewModel.Comment,
                        Date = editViewModel.Date,
                       // RecipeId = editViewModel.RecipeId,
                       // UserId = editViewModel.UserId
                    };
                    await _reviewService.UpdateReviewAsync(review);
                }
                catch (Exception)
                {
                    if (!await ReviewExists(editViewModel.Id))
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
           // ViewData["RecipeId"] = new SelectList(_reviewService.GetAllRecipes(), "Id", "Name", editViewModel.RecipeId);
           // ViewData["UserId"] = new SelectList(_reviewService.GetAllUsers(), "Id", "UserName", editViewModel.UserId);
            return View(editViewModel);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviewService.GetReviewByIdAsync(id.Value);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review != null)
            {
                await _reviewService.DeleteReviewAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ReviewExists(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            return review != null;
        }
    }
}
