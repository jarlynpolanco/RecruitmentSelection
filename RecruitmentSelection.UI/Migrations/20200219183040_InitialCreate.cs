using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSelection.UI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Risk = table.Column<int>(nullable: false),
                    MinimumSalary = table.Column<double>(nullable: false),
                    MaximumSalary = table.Column<double>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    JobPositionID = table.Column<int>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    SalaryWished = table.Column<double>(nullable: false),
                    Languages = table.Column<string>(nullable: false),
                    RecommendedBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Candidates_JobPositions_JobPositionID",
                        column: x => x.JobPositionID,
                        principalTable: "JobPositions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    JobPositionID = table.Column<int>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_JobPositions_JobPositionID",
                        column: x => x.JobPositionID,
                        principalTable: "JobPositions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobExperiences",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bussiness = table.Column<string>(nullable: false),
                    JobPosition = table.Column<string>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobExperiences", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobExperiences_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    State = table.Column<bool>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Languages_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proficiencies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proficiencies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proficiencies_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Institution = table.Column<string>(nullable: false),
                    CandidateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trainings_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_JobPositionID",
                table: "Candidates",
                column: "JobPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobPositionID",
                table: "Employees",
                column: "JobPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_JobExperiences_CandidateID",
                table: "JobExperiences",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CandidateID",
                table: "Languages",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Proficiencies_CandidateID",
                table: "Proficiencies",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CandidateID",
                table: "Trainings",
                column: "CandidateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobExperiences");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Proficiencies");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "JobPositions");
        }
    }
}
