using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class imageUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Locationid",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheoryPagesid",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "theoryid",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_image_Locationid",
                schema: "public",
                table: "image",
                column: "Locationid");

            migrationBuilder.CreateIndex(
                name: "IX_image_TheoryPagesid",
                schema: "public",
                table: "image",
                column: "TheoryPagesid");

            migrationBuilder.AddForeignKey(
                name: "FK_image_Location_Locationid",
                schema: "public",
                table: "image",
                column: "Locationid",
                principalSchema: "public",
                principalTable: "Location",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_image_theorypages_TheoryPagesid",
                schema: "public",
                table: "image",
                column: "TheoryPagesid",
                principalSchema: "public",
                principalTable: "theorypages",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_Location_Locationid",
                schema: "public",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_image_theorypages_TheoryPagesid",
                schema: "public",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_Locationid",
                schema: "public",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_TheoryPagesid",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "Locationid",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "TheoryPagesid",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "theoryid",
                schema: "public",
                table: "image");
        }
    }
}
