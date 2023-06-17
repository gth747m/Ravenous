using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RavenousContext _context;

        public RecipesController(RavenousContext context)
        {
            _context = context;
        }

        private async Task GetMeasurementsAndIngredients()
        {
            var measurements = await _context.Measurements
                .OrderBy(m => m.Name)
                .ToListAsync();
            var ingredients = await _context.Ingredients
                .OrderBy(i => i.Name)
                .ToListAsync();
            ViewBag.Measurements = measurements;
            ViewBag.Ingredients = ingredients;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Where(r => r.RecipeId == id)
                .Include(r => r.Instructions)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(i => i.Measurement)
                .FirstOrDefaultAsync();
            if (recipe == null)
            {
                return NotFound();
            }
            recipe.RecipeIngredients.OrderBy(r => r.Ingredient.Name);
            recipe.Instructions.OrderBy(i => i.Number);

            return View(recipe);
        }

        // GET: Recipes/Create
        public async Task<IActionResult> Create()
        {
            await GetMeasurementsAndIngredients();
            return View(new Recipe());
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,Name,Rating,PrepTime,CookTime")] Recipe recipe, 
            float[] amounts, int[] measurementIds, int[] ingredientIds, string[] instructions)
        {
            if ((amounts.Length != measurementIds.Length) || 
                (amounts.Length != ingredientIds.Length))
            {
                return View(recipe);
            }
            if (ModelState.IsValid)
            {
                for (int i = 0; i < amounts.Length; i++)
                {
                    recipe.RecipeIngredients.Add(new IngredientAssignment
                    {
                        Amount = amounts[i],
                        MeasurementId = measurementIds[i],
                        IngredientId = ingredientIds[i]
                    });
                }
                for (int i = 0; i < instructions.Length; i++)
                {
                    recipe.Instructions.Add(new Instruction { Number = i, Text = instructions[i] });
                }
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(r => r.Ingredient)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(r => r.Measurement)
                .Include(r => r.Instructions)
                .Where(r => r.RecipeId == id.Value)
                .FirstOrDefaultAsync();
            if (recipe == null)
            {
                return NotFound();
            }
            recipe.RecipeIngredients.OrderBy(r => r.Ingredient.Name);
            recipe.Instructions.OrderBy(i => i.Number);
            await GetMeasurementsAndIngredients();
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Name,Rating,PrepTime,CookTime")] Recipe recipe,
            float[] amounts, int[] measurementIds, int[] ingredientIds, string[] instructions)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }
            if ((amounts.Length != measurementIds.Length) || 
                (amounts.Length != ingredientIds.Length))
            {
                return View(recipe);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Remove old ingredients
                    var oldIngredients = await _context.IngredientAssignments
                        .Where(i => i.RecipeId == id)
                        .ToListAsync();
                    foreach (var oldIngredient in oldIngredients)
                    {
                        _context.IngredientAssignments.Remove(oldIngredient);
                    }
                    // Add new ingredients
                    for (int i = 0; i < amounts.Length; i++)
                    {
                        recipe.RecipeIngredients.Add(new IngredientAssignment
                        {
                            Amount = amounts[i],
                            MeasurementId = measurementIds[i],
                            IngredientId = ingredientIds[i]
                        });
                    }
                    // Remove old instructions
                    var oldInstructions = await _context.Instructions
                        .Where(i => i.RecipeId == id)
                        .ToListAsync();
                    foreach (var oldInstruction in oldInstructions)
                    {
                        _context.Instructions.Remove(oldInstruction);
                    }
                    // Add new instructions
                    for (int i = 0; i < instructions.Length; i++)
                    {
                        recipe.Instructions.Add(new Instruction { Number = i, Text = instructions[i] });
                    }
                    // Update the rest of the recipe values
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
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
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
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
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeId == id);
        }
    }
}
