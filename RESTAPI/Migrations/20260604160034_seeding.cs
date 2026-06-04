using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "$2a$11$hash_admin", "admin" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "$2a$11$hash_player1", "player1" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "$2a$11$hash_tester", "tester" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "genre",
                columns: new[] { "id", "genrename" },
                values: new object[,]
                {
                    { 1, "Adventure" },
                    { 2, "Puzzle" },
                    { 3, "Racing" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "theorypages",
                columns: new[] { "id", "description", "imageurl", "title" },
                values: new object[,]
                {
                    { 1, "Understanding movement in games", "http://10.0.2.2:5035/images/WTTTTTTTF.png", "Physics Basics" },
                    { 2, "How game AI reacts to players", "http://10.0.2.2:5035/images/WTTTTTTTF.png", "AI Behavior" },
                    { 3, "Designing engaging game levels", "http://10.0.2.2:5035/images/WTTTTTTTF.png", "Level Design" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Location",
                columns: new[] { "id", "RegionDescription", "RegionName", "genreid" },
                values: new object[,]
                {
                    { 1, "World exploration and quests", "Adventure Region", 1 },
                    { 2, "Logic challenges", "Puzzle Region", 2 },
                    { 3, "Speed and competition", "Racing Region", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Location",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Location",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Location",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "theorypages",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "theorypages",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "theorypages",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "genre",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "genre",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "genre",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
