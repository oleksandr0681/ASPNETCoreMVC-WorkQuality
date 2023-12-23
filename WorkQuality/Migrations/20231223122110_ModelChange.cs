using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkQuality.Migrations
{
    /// <inheritdoc />
    public partial class ModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criteria_Jobs_JobId",
                table: "Criteria");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Examinations_ExaminationId",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_Criteria_JobId",
                table: "Criteria");

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Criteria");

            migrationBuilder.AddColumn<double>(
                name: "AbilityToApplyTechnicalKnowledgePriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProjectManagementSkillsPriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "QualityCustomerServicePriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TechnicalKnowledgePriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AssessmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TechnicalKnowledgeScore = table.Column<int>(type: "int", nullable: false),
                    AbilityToApplyTechnicalKnowledgeScore = table.Column<int>(type: "int", nullable: false),
                    ProjectManagementSkillsScore = table.Column<int>(type: "int", nullable: false),
                    QualityCustomerServiceScore = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_EmployeeId",
                table: "Assessments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Assessments_ExaminationId",
                table: "Scores",
                column: "ExaminationId",
                principalTable: "Assessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Assessments_ExaminationId",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropColumn(
                name: "AbilityToApplyTechnicalKnowledgePriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ProjectManagementSkillsPriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "QualityCustomerServicePriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TechnicalKnowledgePriorityCoefficient",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Criteria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examinations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Criteria",
                columns: new[] { "Id", "Description", "JobId", "Name", "PriorityCoefficient" },
                values: new object[,]
                {
                    { 1, "", null, "Технічні знання і навички", 1.0 },
                    { 2, "", null, "Спроможність застосовувати знання", 1.0 },
                    { 3, "", null, "Якість роботи", 1.0 },
                    { 4, "", null, "Продуктивність", 1.0 },
                    { 5, "Командна робота та комунікативні навички.", null, "Командна робота", 1.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_JobId",
                table: "Criteria",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_EmployeeId",
                table: "Examinations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Criteria_Jobs_JobId",
                table: "Criteria",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Examinations_ExaminationId",
                table: "Scores",
                column: "ExaminationId",
                principalTable: "Examinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
