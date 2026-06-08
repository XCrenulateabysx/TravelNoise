using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class initfixpgsomtnb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageGenre_genre_GenreId",
                schema: "public",
                table: "PageGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_PageGenre_pages_PageId",
                schema: "public",
                table: "PageGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PageGenre",
                schema: "public",
                table: "PageGenre");

            migrationBuilder.RenameTable(
                name: "PageGenre",
                schema: "public",
                newName: "PageGenres",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_PageGenre_GenreId",
                schema: "public",
                table: "PageGenres",
                newName: "IX_PageGenres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageGenres",
                schema: "public",
                table: "PageGenres",
                columns: new[] { "PageId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PageGenres_genre_GenreId",
                schema: "public",
                table: "PageGenres",
                column: "GenreId",
                principalSchema: "public",
                principalTable: "genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PageGenres_pages_PageId",
                schema: "public",
                table: "PageGenres",
                column: "PageId",
                principalSchema: "public",
                principalTable: "pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageGenres_genre_GenreId",
                schema: "public",
                table: "PageGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_PageGenres_pages_PageId",
                schema: "public",
                table: "PageGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PageGenres",
                schema: "public",
                table: "PageGenres");

            migrationBuilder.RenameTable(
                name: "PageGenres",
                schema: "public",
                newName: "PageGenre",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_PageGenres_GenreId",
                schema: "public",
                table: "PageGenre",
                newName: "IX_PageGenre_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageGenre",
                schema: "public",
                table: "PageGenre",
                columns: new[] { "PageId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PageGenre_genre_GenreId",
                schema: "public",
                table: "PageGenre",
                column: "GenreId",
                principalSchema: "public",
                principalTable: "genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PageGenre_pages_PageId",
                schema: "public",
                table: "PageGenre",
                column: "PageId",
                principalSchema: "public",
                principalTable: "pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
