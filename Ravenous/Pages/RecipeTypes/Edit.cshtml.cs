using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.RecipeTypes
{
    public class EditModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public EditModel(Ravenous.Models.DbModels.RavenousContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RecipeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeTypeExists(RecipeType.PkRecipeType))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeTypeExists(int id)
        {
            return _context.RecipeType.Any(e => e.PkRecipeType == id);
        }
    }
}
