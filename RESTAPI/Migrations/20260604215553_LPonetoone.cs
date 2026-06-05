using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class LPonetoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_genre_genreid",
                schema: "public",
                table: "Location");

            migrationBuilder.AlterColumn<int>(
                name: "genreid",
                schema: "public",
                table: "Location",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "pageid",
                schema: "public",
                table: "Location",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_pageid",
                schema: "public",
                table: "Location",
                column: "pageid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_genre_genreid",
                schema: "public",
                table: "Location",
                column: "genreid",
                principalSchema: "public",
                principalTable: "genre",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_pages_pageid",
                schema: "public",
                table: "Location",
                column: "pageid",
                principalSchema: "public",
                principalTable: "pages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_genre_genreid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_pages_pageid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_pageid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "pageid",
                schema: "public",
                table: "Location");

            migrationBuilder.AlterColumn<int>(
                name: "genreid",
                schema: "public",
                table: "Location",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_genre_genreid",
                schema: "public",
                table: "Location",
                column: "genreid",
                principalSchema: "public",
                principalTable: "genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
