using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class imageInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheoryPagesid",
                schema: "public",
                table: "Location",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "theoryId",
                schema: "public",
                table: "Location",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "image",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageURL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_TheoryPagesid",
                schema: "public",
                table: "Location",
                column: "TheoryPagesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_theorypages_TheoryPagesid",
                schema: "public",
                table: "Location",
                column: "TheoryPagesid",
                principalSchema: "public",
                principalTable: "theorypages",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_theorypages_TheoryPagesid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropTable(
                name: "image",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Location_TheoryPagesid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "TheoryPagesid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "theoryId",
                schema: "public",
                table: "Location");
        }
    }
}
