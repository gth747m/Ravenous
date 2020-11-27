using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public partial class Tag
    {
        public Tag()
        {
            RecipeTag = new HashSet<RecipeTag>();
        }

        public int PkTag { get; set; }
        [Required, Display(Name = "Tag Name"), StringLength(64)]
        public string TagName { get; set; }

        public virtual ICollection<RecipeTag> RecipeTag { get; set; }
    }
}
