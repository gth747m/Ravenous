using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages.Ingredients
{
    public partial class IngredientEditPage : ComponentBase
    {
        [Inject]
        public RavenousContext Context { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Ingredient = await Context.Ingredient
                .Where(i => i.IngredientId == Id)
                .FirstOrDefaultAsync();
        }

        public async Task OnValidSumbit()
        {
            await Context.SaveChangesAsync();
            NavBack();
        }

        public async Task OnDelete()
        {
            Context.Ingredient.Remove(Ingredient);
            await Context.SaveChangesAsync();
            NavBack();
        }

        public void OnCancel()
        {
            NavBack();
        }

        public void NavBack()
        {
            Navigation.NavigateTo("/ingredients");
        }
    }
}
