using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class genreTmusiceExerciseOTM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "genreId",
                schema: "public",
                table: "MusicExercises",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicExercises_genreId",
                schema: "public",
                table: "MusicExercises",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicExercises_genre_genreId",
                schema: "public",
                table: "MusicExercises",
                column: "genreId",
                principalSchema: "public",
                principalTable: "genre",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicExercises_genre_genreId",
                schema: "public",
                table: "MusicExercises");

            migrationBuilder.DropIndex(
                name: "IX_MusicExercises_genreId",
                schema: "public",
                table: "MusicExercises");

            migrationBuilder.DropColumn(
                name: "genreId",
                schema: "public",
                table: "MusicExercises");
        }
    }
}
