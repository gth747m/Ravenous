using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Controllers;

public class RecipesController : Controller
{
    private readonly RavenousContext _context;

    public RecipesController(RavenousContext context)
    {
        _context = context;
    }

    private async Task PopulateViewBag()
    {
        var recipeTypes = await _context.RecipeTypes
            .OrderBy(t => t.Name)
            .ToListAsync();
        var measurements = await _context.Measurements
            .OrderBy(m => m.Name)
            .ToListAsync();
        var ingredients = await _context.Ingredients
            .OrderBy(i => i.Name)
            .ToListAsync();
        ViewBag.RecipeTypes = new SelectList(recipeTypes, "RecipeTypeId", "Name");
        ViewBag.Measurements = measurements;
        ViewBag.Ingredients = ingredients;
    }

    // GET: Recipes
    public async Task<IActionResult> Index(int? recipeType)
    {
        var recipes = await _context.Recipes
          .Include(r => r.RecipeType)
          .ToListAsync();
        if (recipeType != null)
        {
            recipes = recipes
                .Where(r => r.RecipeTypeId == recipeType).ToList();
        }
        return View(recipes);
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
            .Include(r => r.IngredientAssignments)
            .ThenInclude(i => i.Ingredient)
            .Include(r => r.IngredientAssignments)
            .ThenInclude(i => i.Measurement)
            .Include(r => r.RecipeType)
            .FirstOrDefaultAsync();
        if (recipe == null)
        {
            return NotFound();
        }
        recipe.IngredientAssignments = recipe.IngredientAssignments.OrderBy(r => r.Ingredient!.Name).ToList();
        recipe.Instructions = recipe.Instructions.OrderBy(i => i.Number).ToList();
        return View(recipe);
    }

    // GET: Recipes/Create
    public async Task<IActionResult> Create()
    {
        await PopulateViewBag();
        return View(new Recipe() { Name = string.Empty });
    }

    // POST: Recipes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("RecipeId,Name,Rating,PrepTime,CookTime,RecipeTypeId")] Recipe recipe,
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
                recipe.IngredientAssignments.Add(new IngredientAssignment
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
            .Include(r => r.IngredientAssignments)
            .ThenInclude(r => r.Ingredient)
            .Include(r => r.IngredientAssignments)
            .ThenInclude(r => r.Measurement)
            .Include(r => r.Instructions)
            .Include(r => r.RecipeType)
            .Where(r => r.RecipeId == id.Value)
            .FirstOrDefaultAsync();
        if (recipe == null)
        {
            return NotFound();
        }
        recipe.IngredientAssignments = recipe.IngredientAssignments.OrderBy(r => r.Ingredient!.Name).ToList();
        recipe.Instructions = recipe.Instructions.OrderBy(i => i.Number).ToList();
        await PopulateViewBag();
        return View(recipe);
    }

    // POST: Recipes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Name,Rating,PrepTime,CookTime,RecipeTypeId")] Recipe recipe,
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
                    recipe.IngredientAssignments.Add(new IngredientAssignment
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
        if (recipe == null)
        {
            return NotFound();
        }
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RecipeExists(int id)
    {
        return _context.Recipes.Any(e => e.RecipeId == id);
    }
}
