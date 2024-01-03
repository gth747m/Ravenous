using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ravenous.Migrations
{
    /// <inheritdoc />
    public partial class TagsAndTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "recipe_type_id",
                table: "recipes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "recipe_types",
                columns: table => new
                {
                    recipe_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipe_types", x => x.recipe_type_id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "tag_assignments",
                columns: table => new
                {
                    tag_assignment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipe_id = table.Column<int>(type: "integer", nullable: false),
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_assignments", x => x.tag_assignment_id);
                    table.ForeignKey(
                        name: "fk_tag_assignments_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "recipe_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tag_assignments_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_recipes_recipe_type_id",
                table: "recipes",
                column: "recipe_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_tag_assignments_recipe_id",
                table: "tag_assignments",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "ix_tag_assignments_tag_id",
                table: "tag_assignments",
                column: "tag_id");

            migrationBuilder.AddForeignKey(
                name: "fk_recipes_recipe_types_recipe_type_id",
                table: "recipes",
                column: "recipe_type_id",
                principalTable: "recipe_types",
                principalColumn: "recipe_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_recipes_recipe_types_recipe_type_id",
                table: "recipes");

            migrationBuilder.DropTable(
                name: "recipe_types");

            migrationBuilder.DropTable(
                name: "tag_assignments");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropIndex(
                name: "ix_recipes_recipe_type_id",
                table: "recipes");

            migrationBuilder.DropColumn(
                name: "recipe_type_id",
                table: "recipes");
        }
    }
}
