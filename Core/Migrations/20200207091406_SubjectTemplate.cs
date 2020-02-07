using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class SubjectTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectStudyPrograms_Subjects_SubjectId",
                table: "SubjectStudyPrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectStudyPrograms",
                table: "SubjectStudyPrograms");

            migrationBuilder.DropIndex(
                name: "IX_SubjectStudyPrograms_SubjectId",
                table: "SubjectStudyPrograms");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "SubjectStudyPrograms");

            migrationBuilder.AddColumn<int>(
                name: "SubjectTemplateId",
                table: "SubjectStudyPrograms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectTemplateId",
                table: "PartOfSubjects",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectStudyPrograms",
                table: "SubjectStudyPrograms",
                columns: new[] { "StudyProgramId", "SubjectTemplateId" });

            migrationBuilder.CreateTable(
                name: "SubjectTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTemplates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStudyPrograms_SubjectTemplateId",
                table: "SubjectStudyPrograms",
                column: "SubjectTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PartOfSubjects_SubjectTemplateId",
                table: "PartOfSubjects",
                column: "SubjectTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartOfSubjects_SubjectTemplates_SubjectTemplateId",
                table: "PartOfSubjects",
                column: "SubjectTemplateId",
                principalTable: "SubjectTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectStudyPrograms_SubjectTemplates_SubjectTemplateId",
                table: "SubjectStudyPrograms",
                column: "SubjectTemplateId",
                principalTable: "SubjectTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOfSubjects_SubjectTemplates_SubjectTemplateId",
                table: "PartOfSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectStudyPrograms_SubjectTemplates_SubjectTemplateId",
                table: "SubjectStudyPrograms");

            migrationBuilder.DropTable(
                name: "SubjectTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectStudyPrograms",
                table: "SubjectStudyPrograms");

            migrationBuilder.DropIndex(
                name: "IX_SubjectStudyPrograms_SubjectTemplateId",
                table: "SubjectStudyPrograms");

            migrationBuilder.DropIndex(
                name: "IX_PartOfSubjects_SubjectTemplateId",
                table: "PartOfSubjects");

            migrationBuilder.DropColumn(
                name: "SubjectTemplateId",
                table: "SubjectStudyPrograms");

            migrationBuilder.DropColumn(
                name: "SubjectTemplateId",
                table: "PartOfSubjects");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "SubjectStudyPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectStudyPrograms",
                table: "SubjectStudyPrograms",
                columns: new[] { "StudyProgramId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStudyPrograms_SubjectId",
                table: "SubjectStudyPrograms",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectStudyPrograms_Subjects_SubjectId",
                table: "SubjectStudyPrograms",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
