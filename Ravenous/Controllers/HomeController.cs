using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ravenous.Models;
using Ravenous.Models.DbModels;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private RavenousContext _context;

    public HomeController(ILogger<HomeController> logger, RavenousContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.RecipeTypes = await _context.RecipeTypes
          .OrderBy(t => t.Name)
          .ToListAsync();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
