using Microsoft.EntityFrameworkCore;

namespace Ravenous.Models
{
    public class RavenousContext : DbContext
    {
        public RavenousContext(DbContextOptions<RavenousContext> options) : base(options)
        {
        }

        public DbSet<Instruction> Instruction { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Measurement> Measurement { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Instruction>()
                .ToTable("Instruction");
            builder.Entity<Ingredient>()
                .ToTable("Ingredient");
            builder.Entity<Measurement>()
                .ToTable("Measurement");
            builder.Entity<Recipe>()
                .ToTable("Recipe");
            builder.Entity<RecipeIngredient>()
                .ToTable("RecipeIngredient");
        }
    }
}