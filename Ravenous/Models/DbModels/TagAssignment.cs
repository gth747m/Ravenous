using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenous.Models.DbModels;

/// <summary>
/// Recipe Tag Assignments
/// </summary>
[Display(Name = "Tag Assignments")]
public class TagAssignment
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int TagAssignmentId { get; set; }
    /// <summary>
    /// Recipe Foreign Key
    /// </summary>
    [ForeignKey(nameof(Models.DbModels.TagAssignment.Recipe))]
    public int RecipeId { get; set; }
    /// <summary>
    /// Tag Foreign Key
    /// </summary>
    [ForeignKey(nameof(Models.DbModels.TagAssignment.Tag))]
    public int TagId { get; set; }

    #region NavigationProperties
    /// <summary>
    /// Recipe the tag is assigned to
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.Recipe.TagAssignments))]
    public virtual Recipe? Recipe { get; set; }
    /// <summary>
    /// The tag assigned to this recipe
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.Tag.TagAssignments))]
    public virtual Tag? Tag { get; set; }
    #endregion
}
