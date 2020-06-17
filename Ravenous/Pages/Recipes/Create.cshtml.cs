using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public CreateModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FkRecipeType"] = new SelectList(
                _context.RecipeType.OrderBy(t => t.RecipeTypeName), 
                "PkRecipeType", "RecipeTypeName");
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await TryUpdateModelAsync<Recipe>(
                Recipe, "recipe",
                r => r.RecipeName,
                r => r.RecipeType))
            {
                _context.Recipe.Add(Recipe);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Edit", new { id = Recipe.PkRecipe });
            }
            return Page();
        }
    }
}
