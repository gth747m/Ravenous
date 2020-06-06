using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models.DbModels;

namespace Ravenous.Pages.Measurements
{
    public class DeleteModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public DeleteModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Measurement Measurement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Measurement = await _context.Measurement.FirstOrDefaultAsync(m => m.PkMeasurement == id);

            if (Measurement == null)
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

            Measurement = await _context.Measurement.FindAsync(id);

            if (Measurement != null)
            {
                _context.Measurement.Remove(Measurement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
