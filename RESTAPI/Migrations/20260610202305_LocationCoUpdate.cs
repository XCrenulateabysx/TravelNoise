using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTAPI.Migrations
{
    /// <inheritdoc />
    public partial class LocationCoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        ALTER TABLE ""public"".""Location""
        ALTER COLUMN ""buttonY"" TYPE real
        USING NULLIF(REPLACE(REPLACE(""buttonY"", 'dp', ''), 'px', ''), '')::real;
    ");

            migrationBuilder.Sql(@"
        ALTER TABLE ""public"".""Location""
        ALTER COLUMN ""buttonX"" TYPE real
        USING NULLIF(REPLACE(REPLACE(""buttonX"", 'dp', ''), 'px', ''), '')::real;
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        ALTER TABLE ""public"".""Location""
        ALTER COLUMN ""buttonY"" TYPE text
        USING ""buttonY""::text;
    ");

            migrationBuilder.Sql(@"
        ALTER TABLE ""public"".""Location""
        ALTER COLUMN ""buttonX"" TYPE text
        USING ""buttonX""::text;
    ");
        }
    }
}
