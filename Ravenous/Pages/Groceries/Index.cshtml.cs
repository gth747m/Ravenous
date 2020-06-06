using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.Groceries
{
    public class IndexModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public IndexModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

        public IList<GroceryList> GroceryList { get;set; }

        public async Task OnGetAsync()
        {
            GroceryList = await _context.GroceryList
                .Include(g => g.Ingredient)
                .Include(g => g.Measurement)
                .OrderBy(g => g.Ingredient.IngredientType)
                .ThenBy(g => g.Ingredient.IngredientName)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
