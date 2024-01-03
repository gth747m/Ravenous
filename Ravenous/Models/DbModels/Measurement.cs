using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenous.Models.DbModels;

/// <summary>
/// Measurement
/// </summary>
[Display(Name = "Measurement")]
public class Measurement
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int MeasurementId { get; set; }
    /// <summary>
    /// Measurement Name
    /// </summary>
    [Display(Name = "Measurement")]
    [Required]
    public required string Name { get; set; }

    #region NavigationProperties
    /// <summary>
    /// Ingredient assignments using this measurement
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.IngredientAssignment.Measurement))]
    public virtual ICollection<IngredientAssignment> IngredientAssignments { get; set; } = new HashSet<IngredientAssignment>();
    #endregion
}