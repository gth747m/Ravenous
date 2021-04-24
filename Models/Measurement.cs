
using System.Collections.Generic;

namespace Ravenous.Models
{
    public class Measurement
    {
        public Measurement()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int MeasurementId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}