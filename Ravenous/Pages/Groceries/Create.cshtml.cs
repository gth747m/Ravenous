using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.Groceries
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
        ViewData["FkIngredient"] = new SelectList(_context.Ingredient, "PkIngredient", "IngredientName");
        ViewData["FkMeasurement"] = new SelectList(_context.Measurement, "PkMeasurement", "MeasurementName");
            return Page();
        }

        [BindProperty]
        public GroceryList GroceryList { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GroceryList.Add(GroceryList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
