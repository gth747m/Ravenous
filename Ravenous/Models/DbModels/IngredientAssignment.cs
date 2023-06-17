using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public class IngredientAssignment
    {
        public int IngredientAssignmentId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int MeasurementId { get; set; }
        [Required, Display(Name="Amount")]
        public float Amount { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Measurement Measurement { get; set; }
    }

}