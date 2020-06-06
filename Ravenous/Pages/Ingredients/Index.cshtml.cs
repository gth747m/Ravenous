using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public IndexModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

        public IList<Ingredient> Ingredient { get;set; }

        public async Task OnGetAsync()
        {
            Ingredient = await _context.Ingredient
                .Include(i => i.IngredientType)
                .OrderBy(i => i.IngredientType.IngredientTypeName)
                .ThenBy(i => i.IngredientName)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
