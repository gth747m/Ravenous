using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public class Instruction
    {
        public int InstructionId { get; set; }
        [Required]
        public int RecipeId { get; set; }
        [Required, Range(1, 999), Display(Name="Step #")]
        public int Number { get; set; }
        [Required, Display(Name="Instruction")]
        public string Text { get; set; }
        
        public virtual Recipe Recipe { get; set; }
    }
}