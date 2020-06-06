using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.Recipies
{
    public class IndexModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public IndexModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipe
                .Include(r => r.RecipeType)
                .OrderBy(r => r.RecipeName)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
