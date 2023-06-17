using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public class Measurement
    {
        public Measurement()
        {
            RecipeIngredients = new HashSet<IngredientAssignment>();
        }

        public int MeasurementId { get; set; }
        [Required, Display(Name="Measurement")]
        public string Name { get; set; }

        public virtual ICollection<IngredientAssignment> RecipeIngredients { get; set; }
    }
}