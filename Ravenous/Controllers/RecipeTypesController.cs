using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Controllers;

public class RecipeTypesController : Controller
{
    private readonly RavenousContext _context;

    public RecipeTypesController(RavenousContext context)
    {
        _context = context;
    }

    // GET: RecipeTypes
    public async Task<IActionResult> Index()
    {
        return View(await _context.RecipeTypes.OrderBy(t => t.Name).ToListAsync());
    }

    // GET: RecipeTypes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var recipeType = await _context.RecipeTypes
            .FirstOrDefaultAsync(m => m.RecipeTypeId == id);
        if (recipeType == null)
        {
            return NotFound();
        }
        return View(recipeType);
    }

    // GET: RecipeTypes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RecipeTypes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("RecipeTypeId,Name")] RecipeType recipeType)
    {
        if (ModelState.IsValid)
        {
            _context.Add(recipeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(recipeType);
    }

    // GET: RecipeTypes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var recipeType = await _context.RecipeTypes.FindAsync(id);
        if (recipeType == null)
        {
            return NotFound();
        }
        return View(recipeType);
    }

    // POST: RecipeTypes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("RecipeTypeId,Name")] RecipeType recipeType)
    {
        if (id != recipeType.RecipeTypeId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(recipeType);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeTypeExists(recipeType.RecipeTypeId))
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
        return View(recipeType);
    }

    // GET: RecipeTypes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var recipeType = await _context.RecipeTypes
            .FirstOrDefaultAsync(m => m.RecipeTypeId == id);
        if (recipeType == null)
        {
            return NotFound();
        }
        return View(recipeType);
    }

    // POST: RecipeTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var recipeType = await _context.RecipeTypes.FindAsync(id);
        if (recipeType != null)
        {
            _context.RecipeTypes.Remove(recipeType);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RecipeTypeExists(int id)
    {
        return _context.RecipeTypes.Any(e => e.RecipeTypeId == id);
    }
}
