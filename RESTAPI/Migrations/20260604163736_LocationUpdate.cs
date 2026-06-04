using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class LocationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "buttonX",
                schema: "public",
                table: "Location",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "buttonY",
                schema: "public",
                table: "Location",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "buttonX",
                schema: "public",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "buttonY",
                schema: "public",
                table: "Location");
        }
    }
}
