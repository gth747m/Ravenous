using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.Ingredients
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
        ViewData["FkIngredientType"] = new SelectList(_context.IngredientType, "PkIngredientType", "IngredientTypeName");
            return Page();
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ingredient.Add(Ingredient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
