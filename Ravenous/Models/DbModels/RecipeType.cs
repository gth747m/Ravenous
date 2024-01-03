using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenous.Models.DbModels;

/// <summary>
/// Type of Recipe
/// </summary>
[Display(Name = "Type")]
public class RecipeType
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int RecipeTypeId { get; set; }
    /// <summary>
    /// Recipe Type Name
    /// </summary>
    [Display(Name = "Name")]
    [Required]
    public required string Name { get; set; }

    #region NavigationProperties
    /// <summary>
    /// Recipes
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.Recipe.RecipeType))]
    public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
    #endregion
}
