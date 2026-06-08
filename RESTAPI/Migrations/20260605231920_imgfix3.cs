using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class imgfix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pages_image_imageid",
                schema: "public",
                table: "pages");

            migrationBuilder.AlterColumn<int>(
                name: "imageid",
                schema: "public",
                table: "pages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_pages_image_imageid",
                schema: "public",
                table: "pages",
                column: "imageid",
                principalSchema: "public",
                principalTable: "image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pages_image_imageid",
                schema: "public",
                table: "pages");

            migrationBuilder.AlterColumn<int>(
                name: "imageid",
                schema: "public",
                table: "pages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pages_image_imageid",
                schema: "public",
                table: "pages",
                column: "imageid",
                principalSchema: "public",
                principalTable: "image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
