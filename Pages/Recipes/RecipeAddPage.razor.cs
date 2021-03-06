using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages.Recipes
{
    public partial class RecipeAddPage : ComponentBase
    {
        [Inject]
        public RavenousContext Context { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public List<Ingredient> IngredientList { get; set; }
        public List<Measurement> MeasurementList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Recipe = new Recipe();
            Recipe.Instructions = new List<Instruction>();
            IngredientList = await Context.Ingredient
                .OrderBy(i => i.Name)
                .ToListAsync();
            MeasurementList = await Context.Measurement
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task OnValidSumbit()
        {
            // Remove empty ingredients
            var ingredientsToRemove = Recipe.RecipeIngredients.Where(i => i.IngredientId == 0).ToList();
            foreach (var i in ingredientsToRemove)
            {
                Recipe.RecipeIngredients.Remove(i);
            }
            // Remove empty instructions
            var instructionsToRemove = Recipe.Instructions.Where(i => String.IsNullOrEmpty(i.Text)).ToList();
            foreach (var i in instructionsToRemove)
            {
                Recipe.Instructions.Remove(i);
            }
            // Order Instructions
            Recipe.OrderInstructions();
            Context.Recipe.Add(Recipe);
            await Context.SaveChangesAsync();
            NavBack();
        }

        public void OnCancel()
        {
            NavBack();
        }

        public void NavBack()
        {
            Navigation.NavigateTo("/recipes");
        }

        public void OnAddIngredient()
        {
            Recipe.RecipeIngredients.Add(new RecipeIngredient());
        }

        public void OnAddInstruction()
        {
            Recipe.Instructions.Add(new Instruction {
                Number = Recipe.Instructions.Count + 1,
            });
        }
    }
}
