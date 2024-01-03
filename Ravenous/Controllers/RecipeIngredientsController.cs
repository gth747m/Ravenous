using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Controllers;

public class RecipeIngredientsController : Controller
{
    private readonly RavenousContext _context;

    public RecipeIngredientsController(RavenousContext context)
    {
        _context = context;
    }

    // GET: RecipeIngredients
    public async Task<IActionResult> Index()
    {
        var ravenousContext = _context.IngredientAssignments.Include(r => r.Ingredient).Include(r => r.Measurement).Include(r => r.Recipe);
        return View(await ravenousContext.ToListAsync());
    }

    // GET: RecipeIngredients/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var recipeIngredient = await _context.IngredientAssignments
            .Include(r => r.Ingredient)
            .Include(r => r.Measurement)
            .Include(r => r.Recipe)
            .FirstOrDefaultAsync(m => m.IngredientAssignmentId == id);
        if (recipeIngredient == null)
        {
            return NotFound();
        }
        return View(recipeIngredient);
    }

    // GET: RecipeIngredients/Create
    public IActionResult Create()
    {
        ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId");
        ViewData["MeasurementId"] = new SelectList(_context.Measurements, "MeasurementId", "MeasurementId");
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "Name");
        return View();
    }

    // POST: RecipeIngredients/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("RecipeIngredientId,RecipeId,IngredientId,MeasurementId,Amount")] IngredientAssignment recipeIngredient)
    {
        if (ModelState.IsValid)
        {
            _context.Add(recipeIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", recipeIngredient.IngredientId);
        ViewData["MeasurementId"] = new SelectList(_context.Measurements, "MeasurementId", "MeasurementId", recipeIngredient.MeasurementId);
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "Name", recipeIngredient.RecipeId);
        return View(recipeIngredient);
    }

    // GET: RecipeIngredients/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var recipeIngredient = await _context.IngredientAssignments.FindAsync(id);
        if (recipeIngredient == null)
        {
            return NotFound();
        }
        ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", recipeIngredient.IngredientId);
        ViewData["MeasurementId"] = new SelectList(_context.Measurements, "MeasurementId", "MeasurementId", recipeIngredient.MeasurementId);
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "Name", recipeIngredient.RecipeId);
        return View(recipeIngredient);
    }

    // POST: RecipeIngredients/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("RecipeIngredientId,RecipeId,IngredientId,MeasurementId,Amount")] IngredientAssignment recipeIngredient)
    {
        if (id != recipeIngredient.IngredientAssignmentId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(recipeIngredient);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientExists(recipeIngredient.IngredientAssignmentId))
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
        ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", recipeIngredient.IngredientId);
        ViewData["MeasurementId"] = new SelectList(_context.Measurements, "MeasurementId", "MeasurementId", recipeIngredient.MeasurementId);
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "Name", recipeIngredient.RecipeId);
        return View(recipeIngredient);
    }

    // GET: RecipeIngredients/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var recipeIngredient = await _context.IngredientAssignments
            .Include(r => r.Ingredient)
            .Include(r => r.Measurement)
            .Include(r => r.Recipe)
            .FirstOrDefaultAsync(m => m.IngredientAssignmentId == id);
        if (recipeIngredient == null)
        {
            return NotFound();
        }
        return View(recipeIngredient);
    }

    // POST: RecipeIngredients/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var recipeIngredient = await _context.IngredientAssignments.FindAsync(id);
        if (recipeIngredient == null)
        {
            return NotFound();
        }
        _context.IngredientAssignments.Remove(recipeIngredient);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RecipeIngredientExists(int id)
    {
        return _context.IngredientAssignments.Any(e => e.IngredientAssignmentId == id);
    }
}
