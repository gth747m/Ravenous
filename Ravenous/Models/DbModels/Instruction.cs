using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenous.Models.DbModels;

/// <summary>
/// Recipe Instructions
/// </summary>
[Display(Name = "Instructions")]
public class Instruction
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int InstructionId { get; set; }
    /// <summary>
    /// Recipe Foreign Key
    /// </summary>
    [Required]
    public int RecipeId { get; set; }
    /// <summary>
    /// Instruction Number
    /// </summary>
    [Display(Name = "Step #")]
    [Range(1, 999)]
    [Required]
    public int Number { get; set; }
    /// <summary>
    /// Instruction Text
    /// </summary>
    [Display(Name = "Instruction")]
    [Required]
    public required string Text { get; set; }

    #region NavigationProperties
    /// <summary>
    /// Recipe this instruction is for
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.Recipe.Instructions))]
    public virtual Recipe? Recipe { get; set; }
    #endregion
}