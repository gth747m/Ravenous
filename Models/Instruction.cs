using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models
{
    public class Instruction
    {
        public Instruction()
        {
        }

        public int InstructionId { get; set; }
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Text { get; set; }
        
        public virtual Recipe Recipe { get; set; }
    }
}