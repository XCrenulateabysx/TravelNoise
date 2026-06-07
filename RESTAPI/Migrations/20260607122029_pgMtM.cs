using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class pgMtM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pages_genre_genreid",
                schema: "public",
                table: "pages");

            migrationBuilder.DropIndex(
                name: "IX_pages_genreid",
                schema: "public",
                table: "pages");

            migrationBuilder.DropColumn(
                name: "genreid",
                schema: "public",
                table: "pages");

            migrationBuilder.CreateTable(
                name: "PageGenre",
                schema: "public",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageGenre", x => new { x.PageId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_PageGenre_genre_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "public",
                        principalTable: "genre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageGenre_pages_PageId",
                        column: x => x.PageId,
                        principalSchema: "public",
                        principalTable: "pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageGenre_GenreId",
                schema: "public",
                table: "PageGenre",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageGenre",
                schema: "public");

            migrationBuilder.AddColumn<int>(
                name: "genreid",
                schema: "public",
                table: "pages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pages_genreid",
                schema: "public",
                table: "pages",
                column: "genreid");

            migrationBuilder.AddForeignKey(
                name: "FK_pages_genre_genreid",
                schema: "public",
                table: "pages",
                column: "genreid",
                principalSchema: "public",
                principalTable: "genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
