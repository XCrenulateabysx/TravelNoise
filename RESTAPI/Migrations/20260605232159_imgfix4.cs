using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class imgfix4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_theorypages_imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropColumn(
                name: "theoryid",
                schema: "public",
                table: "image");

            migrationBuilder.CreateIndex(
                name: "IX_theorypages_imageid",
                schema: "public",
                table: "theorypages",
                column: "imageid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_theorypages_imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.AddColumn<int>(
                name: "theoryid",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_theorypages_imageid",
                schema: "public",
                table: "theorypages",
                column: "imageid",
                unique: true);
        }
    }
}
