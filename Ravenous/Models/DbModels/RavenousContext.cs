using Microsoft.EntityFrameworkCore;

namespace Ravenous.Models.DbModels
{
    public class RavenousContext : DbContext
    {
        public RavenousContext(DbContextOptions<RavenousContext> options) : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientAssignment> IngredientAssignments { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeType> RecipeTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagAssignment> TagAssignments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}