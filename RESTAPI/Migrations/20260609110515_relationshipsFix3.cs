using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class relationshipsFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_genre_theoryPagesId",
                schema: "public",
                table: "genre");

            migrationBuilder.CreateIndex(
                name: "IX_genre_theoryPagesId",
                schema: "public",
                table: "genre",
                column: "theoryPagesId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_genre_theoryPagesId",
                schema: "public",
                table: "genre");

            migrationBuilder.CreateIndex(
                name: "IX_genre_theoryPagesId",
                schema: "public",
                table: "genre",
                column: "theoryPagesId");
        }
    }
}
