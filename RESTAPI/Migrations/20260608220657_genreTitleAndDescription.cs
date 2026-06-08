using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class genreTitleAndDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "genreDescription",
                schema: "public",
                table: "genre",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "genreTitle",
                schema: "public",
                table: "genre",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "genreDescription",
                schema: "public",
                table: "genre");

            migrationBuilder.DropColumn(
                name: "genreTitle",
                schema: "public",
                table: "genre");
        }
    }
}
