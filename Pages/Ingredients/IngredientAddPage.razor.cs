using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages.Ingredients
{
    public partial class IngredientAddPage : ComponentBase
    {
        [Inject]
        public RavenousContext Context { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }

        protected override void OnInitialized()
        {
            Ingredient = new Ingredient();
        }

        public async Task OnValidSumbit()
        {
            Context.Ingredient.Add(Ingredient);
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
