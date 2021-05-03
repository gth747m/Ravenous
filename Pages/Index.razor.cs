using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public RavenousContext Context { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        public List<Recipe> RecipeList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            RecipeList = await Context.Recipe
                .AsNoTracking()
                .OrderBy(r => r.Name)
                .ToListAsync();
        }

        public void OnRecipeClick(int id)
        {
            Navigation.NavigateTo(string.Format("/recipes/edit/{0}", id));
        }

        public void OnAddRecipeClick()
        {
            Navigation.NavigateTo("/recipes/add");
        }
    }
}
