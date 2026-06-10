using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class relationshipsFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genre_theorypages_theoryPagesId",
                schema: "public",
                table: "genre");

            migrationBuilder.AlterColumn<int>(
                name: "theoryPagesId",
                schema: "public",
                table: "genre",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_genre_theorypages_theoryPagesId",
                schema: "public",
                table: "genre",
                column: "theoryPagesId",
                principalSchema: "public",
                principalTable: "theorypages",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genre_theorypages_theoryPagesId",
                schema: "public",
                table: "genre");

            migrationBuilder.AlterColumn<int>(
                name: "theoryPagesId",
                schema: "public",
                table: "genre",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_genre_theorypages_theoryPagesId",
                schema: "public",
                table: "genre",
                column: "theoryPagesId",
                principalSchema: "public",
                principalTable: "theorypages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
