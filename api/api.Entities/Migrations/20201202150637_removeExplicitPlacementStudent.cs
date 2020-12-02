using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Entities.Migrations
{
    public partial class removeExplicitPlacementStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Placements_PlacementId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudentPlacement");

            migrationBuilder.DropIndex(
                name: "IX_Students_PlacementId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PlacementId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlacementStudent",
                columns: table => new
                {
                    PlacementsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementStudent", x => new { x.PlacementsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_PlacementStudent_Placements_PlacementsId",
                        column: x => x.PlacementsId,
                        principalTable: "Placements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacementStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacementStudent_StudentsId",
                table: "PlacementStudent",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacementStudent");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "PlacementId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentPlacement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlacementId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPlacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPlacement_Placements_PlacementId",
                        column: x => x.PlacementId,
                        principalTable: "Placements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPlacement_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_PlacementId",
                table: "Students",
                column: "PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlacement_PlacementId",
                table: "StudentPlacement",
                column: "PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlacement_StudentId",
                table: "StudentPlacement",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Placements_PlacementId",
                table: "Students",
                column: "PlacementId",
                principalTable: "Placements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
