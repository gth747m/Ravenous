using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ravenous.Models.DbModels
{
    public partial class RavenousContext : DbContext
    {
        public RavenousContext()
        {
        }

        public RavenousContext(DbContextOptions<RavenousContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroceryList> GroceryList { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<IngredientType> IngredientType { get; set; }
        public virtual DbSet<Measurement> Measurement { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public virtual DbSet<RecipeStep> RecipeStep { get; set; }
        public virtual DbSet<RecipeTag> RecipeTag { get; set; }
        public virtual DbSet<RecipeType> RecipeType { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryList>(entity =>
            {
                entity.HasKey(e => e.PkGroceryList)
                    .HasName("PRIMARY");

                entity.ToTable("grocery_list");

                entity.HasIndex(e => e.FkIngredient)
                    .HasName("grocery_list_ibfk_1_idx");

                entity.HasIndex(e => e.FkMeasurement)
                    .HasName("grocery_list_ibfk_2_idx");

                entity.Property(e => e.PkGroceryList)
                    .HasColumnName("pk_grocery_list")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FkIngredient)
                    .HasColumnName("fk_ingredient")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FkMeasurement)
                    .HasColumnName("fk_measurement")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IngredientAmount).HasColumnName("ingredient_amount");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.GroceryList)
                    .HasForeignKey(d => d.FkIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grocery_list_ibfk_1");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.GroceryList)
                    .HasForeignKey(d => d.FkMeasurement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grocery_list_ibfk_2");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.PkIngredient)
                    .HasName("PRIMARY");

                entity.ToTable("ingredient");

                entity.HasIndex(e => e.FkIngredientType)
                    .HasName("ingredient_type_ibfk_1_idx");

                entity.HasIndex(e => e.IngredientName)
                    .HasName("ingredient_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PkIngredient)
                    .HasColumnName("pk_ingredient")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FkIngredientType)
                    .HasColumnName("fk_ingredient_type")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasColumnName("ingredient_name")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.IngredientType)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.FkIngredientType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ingredient_ibfk_1");
            });

            modelBuilder.Entity<IngredientType>(entity =>
            {
                entity.HasKey(e => e.PkIngredientType)
                    .HasName("PRIMARY");

                entity.ToTable("ingredient_type");

                entity.HasIndex(e => e.IngredientTypeName)
                    .HasName("ingredient_type_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PkIngredientType)
                    .HasColumnName("pk_ingredient_type")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IngredientTypeName)
                    .IsRequired()
                    .HasColumnName("ingredient_type_name")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasKey(e => e.PkMeasurement)
                    .HasName("PRIMARY");

                entity.ToTable("measurement");

                entity.Property(e => e.PkMeasurement)
                    .HasColumnName("pk_measurement")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.MeasurementName)
                    .IsRequired()
                    .HasColumnName("measurement_name")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.PkRecipe)
                    .HasName("PRIMARY");

                entity.ToTable("recipe");

                entity.HasIndex(e => e.FkRecipeType)
                    .HasName("recipe_type_ibfk_1_idx");

                entity.HasIndex(e => e.RecipeName)
                    .HasName("recipe_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PkRecipe)
                    .HasColumnName("pk_recipe")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CookTime)
                    .HasColumnName("cook_time")
                    .HasDefaultValueSql("'00:00:00'");

                entity.Property(e => e.FkRecipeType)
                    .HasColumnName("fk_recipe_type")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.PrepTime)
                    .HasColumnName("prep_time")
                    .HasDefaultValueSql("'00:00:00'");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("int unsigned")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasColumnName("recipe_name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.RecipeType)
                    .WithMany(p => p.Recipe)
                    .HasForeignKey(d => d.FkRecipeType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_ibfk_1");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(e => e.PkRecipeIngredient)
                    .HasName("PRIMARY");

                entity.ToTable("recipe_ingredient");

                entity.HasIndex(e => e.FkIngredient)
                    .HasName("fk_ingredient_ibfk_1_idx");

                entity.HasIndex(e => e.FkMeasurement)
                    .HasName("fk_recipe_ingredient_ibfk_2_idx");

                entity.Property(e => e.PkRecipeIngredient)
                    .HasColumnName("pk_recipe_ingredient")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FkIngredient)
                    .HasColumnName("fk_ingredient")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FkMeasurement)
                    .HasColumnName("fk_measurement")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IngredientAmount).HasColumnName("ingredient_amount");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredient)
                    .HasForeignKey(d => d.FkIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_ingredient_ibfk_1");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.RecipeIngredient)
                    .HasForeignKey(d => d.FkMeasurement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_ingredient_ibfk_2");
            });

            modelBuilder.Entity<RecipeStep>(entity =>
            {
                entity.HasKey(e => e.PkRecipeStep)
                    .HasName("PRIMARY");

                entity.ToTable("recipe_step");

                entity.HasIndex(e => e.FkRecipe)
                    .HasName("recipe_step_ibfk_1_idx");

                entity.Property(e => e.PkRecipeStep)
                    .HasColumnName("pk_recipe_step")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FkRecipe)
                    .HasColumnName("fk_recipe")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.RecipeStepInstruction)
                    .IsRequired()
                    .HasColumnName("recipe_step_instruction")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeStepNumber)
                    .HasColumnName("recipe_step_number")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeStep)
                    .HasForeignKey(d => d.FkRecipe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_step_ibfk_1");
            });

            modelBuilder.Entity<RecipeTag>(entity =>
            {
                entity.HasKey(e => e.PkRecipeTag)
                    .HasName("PRIMARY");

                entity.ToTable("recipe_tag");

                entity.HasIndex(e => e.FkRecipe)
                    .HasName("recipe_tag_ibfk_1_idx");

                entity.HasIndex(e => e.FkTag)
                    .HasName("recipe_tag_ibfk_2_idx");

                entity.Property(e => e.PkRecipeTag)
                    .HasColumnName("pk_recipe_tag")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FkRecipe)
                    .HasColumnName("fk_recipe")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FkTag)
                    .HasColumnName("fk_tag")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeTag)
                    .HasForeignKey(d => d.FkRecipe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_tag_ibfk_1");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.RecipeTag)
                    .HasForeignKey(d => d.FkTag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipe_tag_ibfk_2");
            });

            modelBuilder.Entity<RecipeType>(entity =>
            {
                entity.HasKey(e => e.PkRecipeType)
                    .HasName("PRIMARY");

                entity.ToTable("recipe_type");

                entity.Property(e => e.PkRecipeType)
                    .HasColumnName("pk_recipe_type")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.RecipeTypeName)
                    .HasColumnName("recipe_type_name")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.PkTag)
                    .HasName("PRIMARY");

                entity.ToTable("tag");

                entity.Property(e => e.PkTag)
                    .HasColumnName("pk_tag")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasColumnName("tag_name")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
