using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class exerciseInitRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "musicExerciseOptionsId",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_image_musicExerciseOptionsId",
                schema: "public",
                table: "image",
                column: "musicExerciseOptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_image_MusicExerciseOptions_musicExerciseOptionsId",
                schema: "public",
                table: "image",
                column: "musicExerciseOptionsId",
                principalSchema: "public",
                principalTable: "MusicExerciseOptions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_MusicExerciseOptions_musicExerciseOptionsId",
                schema: "public",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_musicExerciseOptionsId",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "musicExerciseOptionsId",
                schema: "public",
                table: "image");
        }
    }
}
