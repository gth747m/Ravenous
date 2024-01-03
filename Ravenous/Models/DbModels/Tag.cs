using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ravenous.Models.DbModels;

/// <summary>
/// Recipe Tag
/// </summary>
[Display(Name = "Tag")]
public class Tag
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int TagId { get; set; }
    /// <summary>
    /// Tag Name
    /// </summary>
    [Display(Name = "Tag")]
    [Required]
    public required string Name { get; set; }

    #region NavigationProperties
    /// <summary>
    /// Assignments using this tag
    /// </summary>
    [InverseProperty(nameof(Models.DbModels.TagAssignment.Tag))]
    public virtual ICollection<TagAssignment> TagAssignments { get; set; } = new HashSet<TagAssignment>();
    #endregion
}
