using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infoscreen.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo",
                table: "Locations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExtraInfo", "FloorsInfo", "Name" },
                values: new object[] { null, " Garage ", "Plan 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraInfo",
                table: "Locations");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FloorsInfo", "Name" },
                values: new object[] { "Garage", "PLAN 1" });
        }
    }
}
