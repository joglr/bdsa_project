using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Entities.Migrations
{
    public partial class addStudentCapability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capabilities_Students_StudentId",
                table: "Capabilities");

            migrationBuilder.DropIndex(
                name: "IX_Capabilities_StudentId",
                table: "Capabilities");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Capabilities");

            migrationBuilder.CreateTable(
                name: "CapabilityStudent",
                columns: table => new
                {
                    CapabilitiesId = table.Column<int>(type: "int", nullable: false),
                    PlacementsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilityStudent", x => new { x.CapabilitiesId, x.PlacementsId });
                    table.ForeignKey(
                        name: "FK_CapabilityStudent_Capabilities_CapabilitiesId",
                        column: x => x.CapabilitiesId,
                        principalTable: "Capabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapabilityStudent_Students_PlacementsId",
                        column: x => x.PlacementsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCapabilities",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CapabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCapabilities", x => new { x.StudentId, x.CapabilityId });
                    table.ForeignKey(
                        name: "FK_StudentCapabilities_Capabilities_CapabilityId",
                        column: x => x.CapabilityId,
                        principalTable: "Capabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCapabilities_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapabilityStudent_PlacementsId",
                table: "CapabilityStudent",
                column: "PlacementsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCapabilities_CapabilityId",
                table: "StudentCapabilities",
                column: "CapabilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapabilityStudent");

            migrationBuilder.DropTable(
                name: "StudentCapabilities");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Capabilities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Capabilities_StudentId",
                table: "Capabilities",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capabilities_Students_StudentId",
                table: "Capabilities",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
