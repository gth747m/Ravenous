using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public partial class Measurement
    {
        public Measurement()
        {
            GroceryList = new HashSet<GroceryList>();
            RecipeIngredient = new HashSet<RecipeIngredient>();
        }

        public int PkMeasurement { get; set; }
        [Required, Display(Name = "Measurement")]
        public string MeasurementName { get; set; }

        public virtual ICollection<GroceryList> GroceryList { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredient { get; set; }
    }
}
