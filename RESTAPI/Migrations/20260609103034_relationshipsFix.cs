using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class relationshipsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_MusicExerciseOptions_MusicExerciseOptionsid",
                schema: "public",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_image_imageid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_pages_image_imageid",
                schema: "public",
                table: "pages");

            migrationBuilder.DropForeignKey(
                name: "FK_theorypages_genre_genreId",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropForeignKey(
                name: "FK_theorypages_image_imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropIndex(
                name: "IX_theorypages_genreId",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropIndex(
                name: "IX_theorypages_imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropIndex(
                name: "IX_pages_imageid",
                schema: "public",
                table: "pages");

            migrationBuilder.DropIndex(
                name: "IX_Location_imageid",
                schema: "public",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "genreId",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropColumn(
                name: "imageid",
                schema: "public",
                table: "theorypages");

            migrationBuilder.DropColumn(
                name: "imageid",
                schema: "public",
                table: "pages");

            migrationBuilder.DropColumn(
                name: "imageid",
                schema: "public",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "MusicExerciseOptionsid",
                schema: "public",
                table: "image",
                newName: "theorypagesId");

            migrationBuilder.RenameIndex(
                name: "IX_image_MusicExerciseOptionsid",
                schema: "public",
                table: "image",
                newName: "IX_image_theorypagesId");

            migrationBuilder.AddColumn<int>(
                name: "locationsId",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pagesId",
                schema: "public",
                table: "image",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "theoryPagesId",
                schema: "public",
                table: "genre",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_image_locationsId",
                schema: "public",
                table: "image",
                column: "locationsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_image_pagesId",
                schema: "public",
                table: "image",
                column: "pagesId");

            migrationBuilder.CreateIndex(
                name: "IX_genre_theoryPagesId",
                schema: "public",
                table: "genre",
                column: "theoryPagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_genre_theorypages_theoryPagesId",
                schema: "public",
                table: "genre",
                column: "theoryPagesId",
                principalSchema: "public",
                principalTable: "theorypages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_image_Location_locationsId",
                schema: "public",
                table: "image",
                column: "locationsId",
                principalSchema: "public",
                principalTable: "Location",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_image_pages_pagesId",
                schema: "public",
                table: "image",
                column: "pagesId",
                principalSchema: "public",
                principalTable: "pages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_image_theorypages_theorypagesId",
                schema: "public",
                table: "image",
                column: "theorypagesId",
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

            migrationBuilder.DropForeignKey(
                name: "FK_image_Location_locationsId",
                schema: "public",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_image_pages_pagesId",
                schema: "public",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "FK_image_theorypages_theorypagesId",
                schema: "public",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_locationsId",
                schema: "public",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_pagesId",
                schema: "public",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_genre_theoryPagesId",
                schema: "public",
                table: "genre");

            migrationBuilder.DropColumn(
                name: "locationsId",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "pagesId",
                schema: "public",
                table: "image");

            migrationBuilder.DropColumn(
                name: "theoryPagesId",
                schema: "public",
                table: "genre");

            migrationBuilder.RenameColumn(
                name: "theorypagesId",
                schema: "public",
                table: "image",
                newName: "MusicExerciseOptionsid");

            migrationBuilder.RenameIndex(
                name: "IX_image_theorypagesId",
                schema: "public",
                table: "image",
                newName: "IX_image_MusicExerciseOptionsid");

            migrationBuilder.AddColumn<int>(
                name: "genreId",
                schema: "public",
                table: "theorypages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "imageid",
                schema: "public",
                table: "theorypages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "imageid",
                schema: "public",
                table: "pages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "imageid",
                schema: "public",
                table: "Location",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_theorypages_genreId",
                schema: "public",
                table: "theorypages",
                column: "genreId");

            migrationBuilder.CreateIndex(
                name: "IX_theorypages_imageid",
                schema: "public",
                table: "theorypages",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "IX_pages_imageid",
                schema: "public",
                table: "pages",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "IX_Location_imageid",
                schema: "public",
                table: "Location",
                column: "imageid");

            migrationBuilder.AddForeignKey(
                name: "FK_image_MusicExerciseOptions_MusicExerciseOptionsid",
                schema: "public",
                table: "image",
                column: "MusicExerciseOptionsid",
                principalSchema: "public",
                principalTable: "MusicExerciseOptions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_image_imageid",
                schema: "public",
                table: "Location",
                column: "imageid",
                principalSchema: "public",
                principalTable: "image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pages_image_imageid",
                schema: "public",
                table: "pages",
                column: "imageid",
                principalSchema: "public",
                principalTable: "image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_theorypages_genre_genreId",
                schema: "public",
                table: "theorypages",
                column: "genreId",
                principalSchema: "public",
                principalTable: "genre",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_theorypages_image_imageid",
                schema: "public",
                table: "theorypages",
                column: "imageid",
                principalSchema: "public",
                principalTable: "image",
                principalColumn: "Id");
        }
    }
}
