using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenous.Models.DbModels;

/// <summary>
/// Recipe
/// </summary>
[Display(Name = "Recipe")]
public class Recipe
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int RecipeId { get; set; }
    /// <summary>
    /// Recipe Name
    /// </summary>
    [Display(Name = "Recipe")]
    [Required]
    public required string Name { get; set; }
    /// <summary>
    /// Recipe Rating
    /// </summary>
    [Display(Name = "Rating")]
    [Range(1.0, 5.0)]
    [Required]
    public int Rating { get; set; }
    /// <summary>
    /// Prep Time
    /// </summary>
    [Display(Name = "Prep Time")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
    [Required]
    public TimeOnly PrepTime { get; set; }
    /// <summary>
    /// Cook Time
    /// </summary>
    [Display(Name = "Cook Time")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
    [Required]
    public TimeOnly CookTime { get; set; }
    /// <summary>
    /// RecipeType Foreign Key
    /// </summary>
    [ForeignKey(nameof(Models.DbModels.Recipe.RecipeType))]
    public int? RecipeTypeId { get; set; }

    #region NavigationProperties
    /// <summary>
    /// Ingredient assignments for this recipe
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.IngredientAssignment.Recipe))]
    public virtual ICollection<IngredientAssignment> IngredientAssignments { get; set; } = new HashSet<IngredientAssignment>();
    /// <summary>
    /// Instructions for this recipe
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.Instruction.Recipe))]
    public virtual ICollection<Instruction> Instructions { get; set; } = new HashSet<Instruction>();
    /// <summary>
    /// Tag assignments for this recipe
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.TagAssignment.Recipe))]
    public virtual ICollection<TagAssignment> TagAssignments { get; set; } = new HashSet<TagAssignment>();
    /// <summary>
    /// Recipe Type
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.RecipeType.Recipes))]
    public virtual RecipeType? RecipeType { get; set; }
    #endregion
}
