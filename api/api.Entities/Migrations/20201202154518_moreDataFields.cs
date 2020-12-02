using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Entities.Migrations
{
    public partial class moreDataFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Placements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Placements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxHours",
                table: "Placements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinHours",
                table: "Placements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Placements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Placements");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Placements");

            migrationBuilder.DropColumn(
                name: "MaxHours",
                table: "Placements");

            migrationBuilder.DropColumn(
                name: "MinHours",
                table: "Placements");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Placements");
        }
    }
}
