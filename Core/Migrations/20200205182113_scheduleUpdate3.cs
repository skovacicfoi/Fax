using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class scheduleUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTimeOfTeachings_Subjects_SubjectId",
                table: "SubjectTimeOfTeachings");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTimeOfTeachings_SubjectId",
                table: "SubjectTimeOfTeachings");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "SubjectTimeOfTeachings");

            migrationBuilder.AddColumn<int>(
                name: "PartOfSubjectId",
                table: "SubjectTimeOfTeachings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTimeOfTeachings_PartOfSubjectId",
                table: "SubjectTimeOfTeachings",
                column: "PartOfSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTimeOfTeachings_PartOfSubjects_PartOfSubjectId",
                table: "SubjectTimeOfTeachings",
                column: "PartOfSubjectId",
                principalTable: "PartOfSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTimeOfTeachings_PartOfSubjects_PartOfSubjectId",
                table: "SubjectTimeOfTeachings");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTimeOfTeachings_PartOfSubjectId",
                table: "SubjectTimeOfTeachings");

            migrationBuilder.DropColumn(
                name: "PartOfSubjectId",
                table: "SubjectTimeOfTeachings");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "SubjectTimeOfTeachings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTimeOfTeachings_SubjectId",
                table: "SubjectTimeOfTeachings",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTimeOfTeachings_Subjects_SubjectId",
                table: "SubjectTimeOfTeachings",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
