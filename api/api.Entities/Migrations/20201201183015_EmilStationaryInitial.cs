using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Entities.Migrations
{
    public partial class EmilStationaryInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capabilities_Placements_PlacementId",
                table: "Capabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Capabilities_Placements_PlacementId1",
                table: "Capabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_CapabilityStudent_Students_PlacementsId",
                table: "CapabilityStudent");

            migrationBuilder.DropTable(
                name: "PlacementStudent");

            migrationBuilder.DropIndex(
                name: "IX_Capabilities_PlacementId",
                table: "Capabilities");

            migrationBuilder.DropIndex(
                name: "IX_Capabilities_PlacementId1",
                table: "Capabilities");

            migrationBuilder.DropColumn(
                name: "PlacementId",
                table: "Capabilities");

            migrationBuilder.DropColumn(
                name: "PlacementId1",
                table: "Capabilities");

            migrationBuilder.RenameColumn(
                name: "PlacementsId",
                table: "CapabilityStudent",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_CapabilityStudent_PlacementsId",
                table: "CapabilityStudent",
                newName: "IX_CapabilityStudent_StudentsId");

            migrationBuilder.AddColumn<int>(
                name: "PlacementId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CapabilityPlacement",
                columns: table => new
                {
                    CapabilitiesId = table.Column<int>(type: "int", nullable: false),
                    PlacementsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilityPlacement", x => new { x.CapabilitiesId, x.PlacementsId });
                    table.ForeignKey(
                        name: "FK_CapabilityPlacement_Capabilities_CapabilitiesId",
                        column: x => x.CapabilitiesId,
                        principalTable: "Capabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapabilityPlacement_Placements_PlacementsId",
                        column: x => x.PlacementsId,
                        principalTable: "Placements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPlacement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PlacementId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_CapabilityPlacement_PlacementsId",
                table: "CapabilityPlacement",
                column: "PlacementsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlacement_PlacementId",
                table: "StudentPlacement",
                column: "PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlacement_StudentId",
                table: "StudentPlacement",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CapabilityStudent_Students_StudentsId",
                table: "CapabilityStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Placements_PlacementId",
                table: "Students",
                column: "PlacementId",
                principalTable: "Placements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapabilityStudent_Students_StudentsId",
                table: "CapabilityStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Placements_PlacementId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CapabilityPlacement");

            migrationBuilder.DropTable(
                name: "StudentPlacement");

            migrationBuilder.DropIndex(
                name: "IX_Students_PlacementId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PlacementId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "CapabilityStudent",
                newName: "PlacementsId");

            migrationBuilder.RenameIndex(
                name: "IX_CapabilityStudent_StudentsId",
                table: "CapabilityStudent",
                newName: "IX_CapabilityStudent_PlacementsId");

            migrationBuilder.AddColumn<int>(
                name: "PlacementId",
                table: "Capabilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlacementId1",
                table: "Capabilities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlacementStudent",
                columns: table => new
                {
                    ApplicantsId = table.Column<int>(type: "int", nullable: false),
                    PlacementsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementStudent", x => new { x.ApplicantsId, x.PlacementsId });
                    table.ForeignKey(
                        name: "FK_PlacementStudent_Placements_PlacementsId",
                        column: x => x.PlacementsId,
                        principalTable: "Placements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacementStudent_Students_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capabilities_PlacementId",
                table: "Capabilities",
                column: "PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Capabilities_PlacementId1",
                table: "Capabilities",
                column: "PlacementId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementStudent_PlacementsId",
                table: "PlacementStudent",
                column: "PlacementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capabilities_Placements_PlacementId",
                table: "Capabilities",
                column: "PlacementId",
                principalTable: "Placements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Capabilities_Placements_PlacementId1",
                table: "Capabilities",
                column: "PlacementId1",
                principalTable: "Placements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CapabilityStudent_Students_PlacementsId",
                table: "CapabilityStudent",
                column: "PlacementsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
