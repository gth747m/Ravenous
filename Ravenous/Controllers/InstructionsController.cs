using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Controllers;

public class InstructionsController : Controller
{
    private readonly RavenousContext _context;

    public InstructionsController(RavenousContext context)
    {
        _context = context;
    }

    // GET: Instructions
    public async Task<IActionResult> Index()
    {
        var ravenousContext = _context.Instructions.Include(i => i.Recipe);
        return View(await ravenousContext.ToListAsync());
    }

    // GET: Instructions/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var instruction = await _context.Instructions
            .Include(i => i.Recipe)
            .FirstOrDefaultAsync(m => m.InstructionId == id);
        if (instruction == null)
        {
            return NotFound();
        }
        return View(instruction);
    }

    // GET: Instructions/Create
    public IActionResult Create()
    {
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "Name");
        return View();
    }

    // POST: Instructions/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("InstructionId,RecipeId,Number,Text")] Instruction instruction)
    {
        if (ModelState.IsValid)
        {
            _context.Add(instruction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "Name", instruction.RecipeId);
        return View(instruction);
    }

    // GET: Instructions/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var instruction = await _context.Instructions.FindAsync(id);
        if (instruction == null)
        {
            return NotFound();
        }
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "Name", instruction.RecipeId);
        return View(instruction);
    }

    // POST: Instructions/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("InstructionId,RecipeId,Number,Text")] Instruction instruction)
    {
        if (id != instruction.InstructionId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(instruction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructionExists(instruction.InstructionId))
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
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "Name", instruction.RecipeId);
        return View(instruction);
    }

    // GET: Instructions/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var instruction = await _context.Instructions
            .Include(i => i.Recipe)
            .FirstOrDefaultAsync(m => m.InstructionId == id);
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
        var instruction = await _context.Instructions.FindAsync(id);
        if (instruction == null)
        {
            return NotFound();
        }
        _context.Instructions.Remove(instruction);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool InstructionExists(int id)
    {
        return _context.Instructions.Any(e => e.InstructionId == id);
    }
}
