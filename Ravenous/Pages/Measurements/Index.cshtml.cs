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
    public class IndexModel : PageModel
    {
        private readonly Ravenous.Models.DbModels.RavenousContext _context;

        public IndexModel(Ravenous.Models.DbModels.RavenousContext context)
        {
            _context = context;
        }

        public IList<Measurement> Measurement { get;set; }

        public async Task OnGetAsync()
        {
            Measurement = await _context.Measurement
                .OrderBy(m => m.MeasurementName)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
