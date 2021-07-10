using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Ravenous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Pages.Recipes
{
    public partial class RecipeEditPage : ComponentBase
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
            Recipe = await Context.Recipe
                .Where(i => i.RecipeId == Id)
                .Include(i => i.RecipeIngredients)
                .Include(i => i.Instructions)
                .AsSingleQuery()
                .FirstOrDefaultAsync();
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
            await Context.SaveChangesAsync();
            NavBack();
        }

        public async Task OnDelete()
        {
            Context.Recipe.Remove(Recipe);
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
