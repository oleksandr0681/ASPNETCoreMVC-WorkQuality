using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkQuality.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultJobsInTheDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AbilityToApplyTechnicalKnowledgePriorityCoefficient", "ComplianceOfWorkWithRequirementsPriorityCoefficient", "ContributionToOverallGoalsPriorityCoefficient", "CreativityOfSolutionsPriorityCoefficient", "Description", "Name", "NumberAndSeverityOfErrorsPriorityCoefficient", "ProductivityPriorityCoefficient", "ProjectManagementSkillsPriorityCoefficient", "QualityCustomerServicePriorityCoefficient", "TeamworkPriorityCoefficient", "TechnicalKnowledgePriorityCoefficient", "TrainingAndDevelopmentPriorityCoefficient" },
                values: new object[,]
                {
                    { 1, 1.0, 2.0, 1.0, 1.0, "", "Програміст", 2.0, 1.0, 0.0, 0.0, 1.0, 1.0, 1.0 },
                    { 2, 1.0, 1.0, 1.0, 4.0, "", "Дизайнер", 1.0, 1.0, 0.0, 0.0, 1.0, 1.0, 1.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
