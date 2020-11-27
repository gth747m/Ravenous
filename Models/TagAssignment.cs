using Ravenous.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            context.Tag.ToList().ForEach(t => assignments.Add(new TagAssignment
            {
                TagName = t.TagName,
                PkTag = t.PkTag,
                Assigned = tags.Contains(t.PkTag)
            }));

            return assignments;
        }

        public static void SetTagAssignments(
            RavenousContext context,
            Recipe recipe,
            string[] selectedTags)
        {
            if (recipe.RecipeTag == null)
            {
                recipe.RecipeTag = new List<RecipeTag>();
            }
            HashSet<string> selectedHashSet = new HashSet<string>(selectedTags);
            HashSet<int> currentTags = new HashSet<int>(recipe.RecipeTag.Select(t => t.FkTag));
            foreach(Tag tag in context.Tag)
            {
                // User wants this tag assigned
                if (selectedHashSet.Contains(tag.TagName))
                {
                    // If it doesn't have this tag yet
                    if (!currentTags.Contains(tag.PkTag))
                    {
                        recipe.RecipeTag.Add(
                            new RecipeTag
                            {
                                FkRecipe = recipe.PkRecipe,
                                FkTag = tag.PkTag
                            });
                    }
                }
                else // User doesn't want this tag
                {
                    // If it currently has this tag
                    if (currentTags.Contains(tag.PkTag))
                    {
                        RecipeTag tagToDelete = recipe.RecipeTag
                            .SingleOrDefault(t => t.FkTag == tag.PkTag);
                        context.Remove(tagToDelete);
                    }
                }
            }
        }
    }
}
