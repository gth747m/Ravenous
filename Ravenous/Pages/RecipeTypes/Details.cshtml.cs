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
    public class DetailsModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public DetailsModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

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
    }
}
