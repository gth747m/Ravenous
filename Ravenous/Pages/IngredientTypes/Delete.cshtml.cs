using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.IngredientTypes
{
    public class DeleteModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public DeleteModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IngredientType IngredientType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IngredientType = await _context.IngredientType.FirstOrDefaultAsync(m => m.PkIngredientType == id);

            if (IngredientType == null)
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

            IngredientType = await _context.IngredientType.FindAsync(id);

            if (IngredientType != null)
            {
                _context.IngredientType.Remove(IngredientType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
