using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class pageImageotm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pageid",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_image_pageid",
                schema: "public",
                table: "image",
                column: "pageid");

            migrationBuilder.AddForeignKey(
                name: "FK_image_pages_pageid",
                schema: "public",
                table: "image",
                column: "pageid",
                principalSchema: "public",
                principalTable: "pages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_pages_pageid",
                schema: "public",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_pageid",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "pageid",
                schema: "public",
                table: "image");
        }
    }
}
