using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class imgfix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_theorypages_image_imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.AlterColumn<int>(
                name: "imageid",
                schema: "public",
                table: "theorypages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_theorypages_image_imageid",
                schema: "public",
                table: "theorypages",
                column: "imageid",
                principalSchema: "public",
                principalTable: "image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_theorypages_image_imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.AlterColumn<int>(
                name: "imageid",
                schema: "public",
                table: "theorypages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_theorypages_image_imageid",
                schema: "public",
                table: "theorypages",
                column: "imageid",
                principalSchema: "public",
                principalTable: "image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
