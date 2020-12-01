using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Entities.Migrations
{
    public partial class removeRedundantJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCapabilities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_StudentCapabilities_CapabilityId",
                table: "StudentCapabilities",
                column: "CapabilityId");
        }
    }
}
