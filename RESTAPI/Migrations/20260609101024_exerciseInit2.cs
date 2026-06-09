using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class exerciseInit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MusicExerciseOptionsid",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MusicExercises",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: false),
                    question = table.Column<string>(type: "text", nullable: true),
                    videoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicExercises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MusicExerciseOptions",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    MusicExerciseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicExerciseOptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_MusicExerciseOptions_MusicExercises_MusicExerciseId",
                        column: x => x.MusicExerciseId,
                        principalSchema: "public",
                        principalTable: "MusicExercises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_image_MusicExerciseOptionsid",
                schema: "public",
                table: "image",
                column: "MusicExerciseOptionsid");

            migrationBuilder.CreateIndex(
                name: "IX_MusicExerciseOptions_MusicExerciseId",
                schema: "public",
                table: "MusicExerciseOptions",
                column: "MusicExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_image_MusicExerciseOptions_MusicExerciseOptionsid",
                schema: "public",
                table: "image",
                column: "MusicExerciseOptionsid",
                principalSchema: "public",
                principalTable: "MusicExerciseOptions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_MusicExerciseOptions_MusicExerciseOptionsid",
                schema: "public",
                table: "image");

            migrationBuilder.DropTable(
                name: "MusicExerciseOptions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "MusicExercises",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_image_MusicExerciseOptionsid",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "MusicExerciseOptionsid",
                schema: "public",
                table: "image");
        }
    }
}
