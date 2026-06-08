using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class addtpTGenreOtM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "theoryId",
                schema: "public",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "genreId",
                schema: "public",
                table: "theorypages",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_theorypages_genreId",
                schema: "public",
                table: "theorypages",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_theorypages_genre_genreId",
                schema: "public",
                table: "theorypages",
                column: "genreId",
                principalSchema: "public",
                principalTable: "genre",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_theorypages_genre_genreId",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropIndex(
                name: "IX_theorypages_genreId",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropColumn(
                name: "genreId",
                schema: "public",
                table: "theorypages");

            migrationBuilder.AddColumn<int>(
                name: "theoryId",
                schema: "public",
                table: "Location",
                type: "integer",
                nullable: true);
        }
    }
}
