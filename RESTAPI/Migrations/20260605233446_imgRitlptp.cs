using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class imgRitlptp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageLocation",
                schema: "public");

            migrationBuilder.AddColumn<int>(
                name: "imageid",
                schema: "public",
                table: "Location",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_imageid",
                schema: "public",
                table: "Location",
                column: "imageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_image_imageid",
                schema: "public",
                table: "Location",
                column: "imageid",
                principalSchema: "public",
                principalTable: "image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_image_imageid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_imageid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "imageid",
                schema: "public",
                table: "Location");

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
                name: "IX_ImageLocation_locationsid",
                schema: "public",
                table: "ImageLocation",
                column: "locationsid");
        }
    }
}
