using Microsoft.AspNetCore.Components;
using Ravenous.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages
{
    public partial class IngredientsPage : ComponentBase
    {
        [Inject]
        public RavenousContext Context { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

        protected override void OnInitialized()
        {
            Ingredients = Context.Ingredient
                .ToList();
        }
    }
}