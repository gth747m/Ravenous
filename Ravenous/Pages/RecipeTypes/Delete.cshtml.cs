using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.RecipeTypes
{
    public class DeleteModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public DeleteModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeType RecipeType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeType = await _context.RecipeType.FirstOrDefaultAsync(m => m.PkRecipeType == id);

            if (RecipeType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeType = await _context.RecipeType.FindAsync(id);

            if (RecipeType != null)
            {
                _context.RecipeType.Remove(RecipeType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
