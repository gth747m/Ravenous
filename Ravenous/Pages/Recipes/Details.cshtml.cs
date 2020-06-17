using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public DetailsModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipe
                .Include(r => r.RecipeType).FirstOrDefaultAsync(m => m.PkRecipe == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
