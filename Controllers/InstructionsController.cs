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
    public class InstructionsController : Controller
    {
        private readonly IInstructionService _instructionService;

        public InstructionsController(IInstructionService instructionService)
        {
            _instructionService = instructionService;
        }

        // GET: Instructions
        public async Task<IActionResult> Index()
        {
            var instructions = await _instructionService.GetAllInstructionsAsync();
            return View(instructions);
        }

        // GET: Instructions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _instructionService.GetInstructionByIdAsync(id.Value);
            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Instructions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructionViewModel instructionViewModel)
        {
            if (ModelState.IsValid)
            {
                var instruction = new Instruction
                {
                    Id = instructionViewModel.Id,
                    StepNumber = instructionViewModel.StepNumber,
                    Description = instructionViewModel.Description,
                    // RecipeId = instructionViewModel.RecipeId
                };

                await _instructionService.AddInstructionAsync(instruction);
                return RedirectToAction(nameof(Index));
            }
            return View(instructionViewModel);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Instructions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _instructionService.GetInstructionByIdAsync(id.Value);
            if (instruction == null)
            {
                return NotFound();
            }

            var editViewModel = new InstructionViewModel
            {
                Id = instruction.Id,
                StepNumber = instruction.StepNumber,
                Description = instruction.Description,
                // RecipeId = instruction.RecipeId
            };

            return View(editViewModel);
        }

        // POST: Instructions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InstructionViewModel editViewModel)
        {
            if (id != editViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var instruction = new Instruction
                    {
                        Id = editViewModel.Id,
                        StepNumber = editViewModel.StepNumber,
                        Description = editViewModel.Description,
                        // RecipeId = editViewModel.RecipeId
                    };
                    await _instructionService.UpdateInstructionAsync(instruction);
                }
                catch (Exception)
                {
                    if (!await InstructionExists(editViewModel.Id))
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
        // GET: Instructions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruction = await _instructionService.GetInstructionByIdAsync(id.Value);
            if (instruction == null)
            {
                return NotFound();
            }

            return View(instruction);
        }

        // POST: Instructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instruction = await _instructionService.GetInstructionByIdAsync(id);
            if (instruction != null)
            {
                await _instructionService.DeleteInstructionAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> InstructionExists(int id)
        {
            var instruction = await _instructionService.GetInstructionByIdAsync(id);
            return instruction != null;
        }
    }
}
