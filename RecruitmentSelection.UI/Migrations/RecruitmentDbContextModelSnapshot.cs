﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitmentSelection.UI.Models.Context;

namespace RecruitmentSelection.UI.Migrations
{
    [DbContext(typeof(RecruitmentDbContext))]
    partial class RecruitmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Candidate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobPositionID")
                        .HasColumnType("int");

                    b.Property<string>("Languages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecommendedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SalaryWished")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("JobPositionID");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobPositionID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("JobPositionID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.JobExperience", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bussiness")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("CandidateID");

                    b.ToTable("JobExperiences");
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.JobPosition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("MaximumSalary")
                        .HasColumnType("float");

                    b.Property<double>("MinimumSalary")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Risk")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("JobPositions");
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Languages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CandidateID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Proficiency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CandidateID");

                    b.ToTable("Proficiencies");
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Training", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CandidateID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Candidate", b =>
                {
                    b.HasOne("RecruitmentSelection.UI.Models.JobPosition", "JobPosition")
                        .WithMany()
                        .HasForeignKey("JobPositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Employee", b =>
                {
                    b.HasOne("RecruitmentSelection.UI.Models.JobPosition", "JobPosition")
                        .WithMany()
                        .HasForeignKey("JobPositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.JobExperience", b =>
                {
                    b.HasOne("RecruitmentSelection.UI.Models.Candidate", "Candidate")
                        .WithMany("JobExperiences")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Languages", b =>
                {
                    b.HasOne("RecruitmentSelection.UI.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Proficiency", b =>
                {
                    b.HasOne("RecruitmentSelection.UI.Models.Candidate", "Candidate")
                        .WithMany("Proficiencies")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecruitmentSelection.UI.Models.Training", b =>
                {
                    b.HasOne("RecruitmentSelection.UI.Models.Candidate", "Candidate")
                        .WithMany("Trainings")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}