using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class UserStudyProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "Faculties",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserStudyPrograms",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    StudyProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStudyPrograms", x => new { x.StudyProgramId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserStudyPrograms_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStudyPrograms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStudyPrograms_UserId",
                table: "UserStudyPrograms",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStudyPrograms");

            migrationBuilder.DropColumn(
                name: "University",
                table: "Faculties");
        }
    }
}
