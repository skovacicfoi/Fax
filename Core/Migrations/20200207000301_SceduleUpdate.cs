using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class SceduleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_StudyPrograms_StudyProgramId",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "StudyProgramId",
                table: "Schedules",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_StudyPrograms_StudyProgramId",
                table: "Schedules",
                column: "StudyProgramId",
                principalTable: "StudyPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_StudyPrograms_StudyProgramId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "StudyProgramId",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_StudyPrograms_StudyProgramId",
                table: "Schedules",
                column: "StudyProgramId",
                principalTable: "StudyPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
