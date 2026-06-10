using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class relationshipsFix4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genre_theorypages_theoryPagesId",
                schema: "public",
                table: "genre");

            migrationBuilder.DropIndex(
                name: "IX_genre_theoryPagesId",
                schema: "public",
                table: "genre");

            migrationBuilder.DropColumn(
                name: "theoryPagesId",
                schema: "public",
                table: "genre");

            migrationBuilder.AddColumn<int>(
                name: "genreId",
                schema: "public",
                table: "theorypages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
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
                name: "theoryPagesId",
                schema: "public",
                table: "genre",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_genre_theoryPagesId",
                schema: "public",
                table: "genre",
                column: "theoryPagesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_genre_theorypages_theoryPagesId",
                schema: "public",
                table: "genre",
                column: "theoryPagesId",
                principalSchema: "public",
                principalTable: "theorypages",
                principalColumn: "id");
        }
    }
}
