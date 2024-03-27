using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO_Project_Data.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KoronaDiseasesData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnosis = table.Column<DateTime>(type: "DATE", nullable: false),
                    recovery = table.Column<DateTime>(type: "DATE", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoronaDiseasesData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineProducersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineProducersData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    houseNumber = table.Column<int>(type: "int", nullable: false),
                    birthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobilePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KoronaDiseaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembersData_KoronaDiseasesData_KoronaDiseaseId",
                        column: x => x.KoronaDiseaseId,
                        principalTable: "KoronaDiseasesData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VaccinationsData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineProducerId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    recieveDate = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationsData_MembersData_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MembersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationsData_VaccineProducersData_VaccineProducerId",
                        column: x => x.VaccineProducerId,
                        principalTable: "VaccineProducersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembersData_KoronaDiseaseId",
                table: "MembersData",
                column: "KoronaDiseaseId",
                unique: true,
                filter: "[KoronaDiseaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationsData_MemberId",
                table: "VaccinationsData",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationsData_VaccineProducerId",
                table: "VaccinationsData",
                column: "VaccineProducerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationsData");

            migrationBuilder.DropTable(
                name: "MembersData");

            migrationBuilder.DropTable(
                name: "VaccineProducersData");

            migrationBuilder.DropTable(
                name: "KoronaDiseasesData");
        }
    }
}
