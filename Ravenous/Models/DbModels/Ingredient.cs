using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenous.Models.DbModels;

/// <summary>
/// Ingredient
/// </summary>
[Display(Name = "Ingredient")]
public class Ingredient
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int IngredientId { get; set; }
    /// <summary>
    /// Ingredient Name
    /// </summary>
    [Display(Name = "Ingredient")]
    [Required]
    public required string Name { get; set; }

    #region NavigationProperties
    /// <summary>
    /// Assignments of this ingredient to recipes
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.IngredientAssignment.Ingredient))]
    public virtual ICollection<IngredientAssignment> IngredientAssignments { get; set; } = new HashSet<IngredientAssignment>();
    #endregion
}