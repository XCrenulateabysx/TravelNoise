using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class imageRFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_Location_Locationid",
                schema: "public",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_image_pages_pageid",
                schema: "public",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_image_theorypages_TheoryPagesid",
                schema: "public",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_theorypages_TheoryPagesid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_TheoryPagesid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_image_Locationid",
                schema: "public",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_pageid",
                schema: "public",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_TheoryPagesid",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "imageurl",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropColumn(
                name: "TheoryPagesid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Locationid",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "TheoryPagesid",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "pageid",
                schema: "public",
                table: "image");

            migrationBuilder.AddColumn<int>(
                name: "imageid",
                schema: "public",
                table: "theorypages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "imageid",
                schema: "public",
                table: "pages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImageLocation",
                schema: "public",
                columns: table => new
                {
                    imagesId = table.Column<int>(type: "integer", nullable: false),
                    locationsid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageLocation", x => new { x.imagesId, x.locationsid });
                    table.ForeignKey(
                        name: "FK_ImageLocation_Location_locationsid",
                        column: x => x.locationsid,
                        principalSchema: "public",
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageLocation_image_imagesId",
                        column: x => x.imagesId,
                        principalSchema: "public",
                        principalTable: "image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_theorypages_imageid",
                schema: "public",
                table: "theorypages",
                column: "imageid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pages_imageid",
                schema: "public",
                table: "pages",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLocation_locationsid",
                schema: "public",
                table: "ImageLocation",
                column: "locationsid");

            migrationBuilder.AddForeignKey(
                name: "FK_pages_image_imageid",
                schema: "public",
                table: "pages",
                column: "imageid",
                principalSchema: "public",
                principalTable: "image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pages_image_imageid",
                schema: "public",
                table: "pages");

            migrationBuilder.DropForeignKey(
                name: "FK_theorypages_image_imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropTable(
                name: "ImageLocation",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_theorypages_imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropIndex(
                name: "IX_pages_imageid",
                schema: "public",
                table: "pages");

            migrationBuilder.DropColumn(
                name: "imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropColumn(
                name: "imageid",
                schema: "public",
                table: "pages");

            migrationBuilder.AddColumn<string>(
                name: "imageurl",
                schema: "public",
                table: "theorypages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TheoryPagesid",
                schema: "public",
                table: "Location",
                type: "integer",
                nullable: true);

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
                name: "pageid",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_TheoryPagesid",
                schema: "public",
                table: "Location",
                column: "TheoryPagesid");

            migrationBuilder.CreateIndex(
                name: "IX_image_Locationid",
                schema: "public",
                table: "image",
                column: "Locationid");

            migrationBuilder.CreateIndex(
                name: "IX_image_pageid",
                schema: "public",
                table: "image",
                column: "pageid");

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
                name: "FK_image_pages_pageid",
                schema: "public",
                table: "image",
                column: "pageid",
                principalSchema: "public",
                principalTable: "pages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_image_theorypages_TheoryPagesid",
                schema: "public",
                table: "image",
                column: "TheoryPagesid",
                principalSchema: "public",
                principalTable: "theorypages",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_theorypages_TheoryPagesid",
                schema: "public",
                table: "Location",
                column: "TheoryPagesid",
                principalSchema: "public",
                principalTable: "theorypages",
                principalColumn: "id");
        }
    }
}
