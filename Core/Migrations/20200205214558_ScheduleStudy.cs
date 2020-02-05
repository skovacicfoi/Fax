using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class ScheduleStudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudyProgram_StudyProgramId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudyProgramId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudyProgramId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "StudyProgramId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_StudyProgramId",
                table: "Schedules",
                column: "StudyProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_StudyProgram_StudyProgramId",
                table: "Schedules",
                column: "StudyProgramId",
                principalTable: "StudyProgram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_StudyProgram_StudyProgramId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_StudyProgramId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "StudyProgramId",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "StudyProgramId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudyProgramId",
                table: "AspNetUsers",
                column: "StudyProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudyProgram_StudyProgramId",
                table: "AspNetUsers",
                column: "StudyProgramId",
                principalTable: "StudyProgram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
