using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkQuality.Migrations
{
    /// <inheritdoc />
    public partial class PropertiesChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "AssessmentDate",
                table: "Assessments",
                newName: "AssessDate");

            migrationBuilder.AddColumn<double>(
                name: "ComplianceOfWorkWithRequirementsPriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ContributionToOverallGoalsPriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CreativityOfSolutionsPriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NumberAndSeverityOfErrorsPriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProductivityPriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TeamworkPriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TrainingAndDevelopmentPriorityCoefficient",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TechnicalKnowledgeScore",
                table: "Assessments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Assessments",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "QualityCustomerServiceScore",
                table: "Assessments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectManagementSkillsScore",
                table: "Assessments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AbilityToApplyTechnicalKnowledgeScore",
                table: "Assessments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ComplianceOfWorkWithRequirementsScore",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContributionToOverallGoalsScore",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreativityOfSolutionsScore",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberAndSeverityOfErrorsScore",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductivityScore",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamworkScore",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingAndDevelopmentScore",
                table: "Assessments",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComplianceOfWorkWithRequirementsPriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ContributionToOverallGoalsPriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreativityOfSolutionsPriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "NumberAndSeverityOfErrorsPriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ProductivityPriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TeamworkPriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TrainingAndDevelopmentPriorityCoefficient",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ComplianceOfWorkWithRequirementsScore",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "ContributionToOverallGoalsScore",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "CreativityOfSolutionsScore",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "NumberAndSeverityOfErrorsScore",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "ProductivityScore",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "TeamworkScore",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "TrainingAndDevelopmentScore",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "AssessDate",
                table: "Assessments",
                newName: "AssessmentDate");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TechnicalKnowledgeScore",
                table: "Assessments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Assessments",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QualityCustomerServiceScore",
                table: "Assessments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectManagementSkillsScore",
                table: "Assessments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AbilityToApplyTechnicalKnowledgeScore",
                table: "Assessments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
