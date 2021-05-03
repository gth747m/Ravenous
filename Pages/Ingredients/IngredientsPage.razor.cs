using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages.Ingredients
{
    public partial class IngredientsPage : ComponentBase
    {
        [Inject]
        public RavenousContext Context { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        protected override void OnInitialized()
        {
            Ingredients = Context.Ingredient
                .AsNoTracking()
                .OrderBy(i => i.Name)
                .ToList();
        }
        
        public void OnIngredientClick(int id)
        {
            Navigation.NavigateTo(string.Format("/ingredients/edit/{0}", id));
        }

        public void OnAddIngredientClick()
        {
            Navigation.NavigateTo("/ingredients/add");
        }
    }
}