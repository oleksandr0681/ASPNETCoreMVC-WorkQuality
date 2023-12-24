﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkQuality.Models;

#nullable disable

namespace WorkQuality.Migrations
{
    [DbContext(typeof(WorkQualityDbContext))]
    [Migration("20231224142519_PropertiesChange2")]
    partial class PropertiesChange2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkQuality.Models.Assessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AbilityToApplyTechnicalKnowledgeScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("AssessDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ComplianceOfWorkWithRequirementsScore")
                        .HasColumnType("int");

                    b.Property<int?>("ContributionToOverallGoalsScore")
                        .HasColumnType("int");

                    b.Property<int?>("CreativityOfSolutionsScore")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("NumberAndSeverityOfErrorsScore")
                        .HasColumnType("int");

                    b.Property<int?>("ProductivityScore")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectManagementSkillsScore")
                        .HasColumnType("int");

                    b.Property<int?>("QualityCustomerServiceScore")
                        .HasColumnType("int");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<int?>("TeamworkScore")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicalKnowledgeScore")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingAndDevelopmentScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("WorkQuality.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WorkQuality.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AbilityToApplyTechnicalKnowledgePriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("ComplianceOfWorkWithRequirementsPriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("ContributionToOverallGoalsPriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("CreativityOfSolutionsPriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("NumberAndSeverityOfErrorsPriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("ProductivityPriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("ProjectManagementSkillsPriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("QualityCustomerServicePriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("TeamworkPriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("TechnicalKnowledgePriorityCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("TrainingAndDevelopmentPriorityCoefficient")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("WorkQuality.Models.Assessment", b =>
                {
                    b.HasOne("WorkQuality.Models.Employee", "Employee")
                        .WithMany("Assessments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WorkQuality.Models.Employee", b =>
                {
                    b.HasOne("WorkQuality.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("WorkQuality.Models.Employee", b =>
                {
                    b.Navigation("Assessments");
                });
#pragma warning restore 612, 618
        }
    }
}
