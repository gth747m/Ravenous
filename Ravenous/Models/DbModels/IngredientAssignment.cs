using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenous.Models.DbModels;

/// <summary>
/// Ingredient Assignments
/// </summary>
[Display(Name = "Ingredient Assignments")]
public class IngredientAssignment
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int IngredientAssignmentId { get; set; }
    /// <summary>
    /// Recipe Foreign Key
    /// </summary>
    [ForeignKey(nameof(Models.DbModels.IngredientAssignment.Recipe))]
    public int RecipeId { get; set; }
    /// <summary>
    /// Ingredient Foreign Key
    /// </summary>
    [ForeignKey(nameof(Models.DbModels.IngredientAssignment.Ingredient))]
    public int IngredientId { get; set; }
    /// <summary>
    /// Measurement Foreign Key
    /// </summary>
    [ForeignKey(nameof(Models.DbModels.IngredientAssignment.Measurement))]
    public int MeasurementId { get; set; }
    /// <summary>
    /// Ingredient Amount
    /// </summary>
    [Display(Name = "Amount")]
    [Required]
    public float Amount { get; set; }

    #region NavigationProperties
    /// <summary>
    /// Recipe this ingredient is being assigned to
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.Recipe.IngredientAssignments))]
    public virtual Recipe? Recipe { get; set; }
    /// <summary>
    /// Ingredient being assigned to a recipe
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.Ingredient.IngredientAssignments))]
    public virtual Ingredient? Ingredient { get; set; }
    /// <summary>
    /// Measurement for the given amount of ingredient
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.Measurement.IngredientAssignments))]
    public virtual Measurement? Measurement { get; set; }
    #endregion
}