using NUglify.Helpers;
using Ravenous.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenous.Models
{
    /// <summary>
    /// Tag assignment model
    /// </summary>
    public class TagAssignment
    {
        /// <summary>
        /// Tag name
        /// </summary>
        [Display(Name = "Tag")]
        public String TagName { get; set; }
        /// <summary>
        /// Tag primary key
        /// </summary>
        public int PkTag { get; set; }
        /// <summary>
        /// Is this tag currently assigned?
        /// </summary>
        public bool Assigned { get; set; }

        /// <summary>
        /// Get a list of all tags and which ones are currently assigned to a recipe
        /// </summary>
        /// <param name="context">Context for retrieving tags</param>
        /// <param name="recipe">Recipe to get assingments for</param>
        /// <returns></returns>
        public static List<TagAssignment> GetTagAssignments(
            RavenousContext context,
            Recipe recipe)
        {
            var assignments = new List<TagAssignment>();
            var tags = recipe.RecipeTag.Select(t => t.FkTag);
            context.Tag.ForEach(t => assignments.Add(new TagAssignment
            {
                TagName = t.TagName,
                PkTag = t.PkTag,
                Assigned = tags.Contains(t.PkTag)
            }));

            return assignments;
        }
    }
}
