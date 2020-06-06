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
    public class DetailsModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public DetailsModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

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
    }
}
