using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO_Project_Data.Migrations
{
    public partial class fk_issue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembersData_KoronaDiseasesData_KoronaDiseaseId",
                table: "MembersData");

            migrationBuilder.DropIndex(
                name: "IX_MembersData_KoronaDiseaseId",
                table: "MembersData");

            migrationBuilder.CreateIndex(
                name: "IX_KoronaDiseasesData_MemberId",
                table: "KoronaDiseasesData",
                column: "MemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KoronaDiseasesData_MembersData_MemberId",
                table: "KoronaDiseasesData",
                column: "MemberId",
                principalTable: "MembersData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KoronaDiseasesData_MembersData_MemberId",
                table: "KoronaDiseasesData");

            migrationBuilder.DropIndex(
                name: "IX_KoronaDiseasesData_MemberId",
                table: "KoronaDiseasesData");

            migrationBuilder.CreateIndex(
                name: "IX_MembersData_KoronaDiseaseId",
                table: "MembersData",
                column: "KoronaDiseaseId",
                unique: true,
                filter: "[KoronaDiseaseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MembersData_KoronaDiseasesData_KoronaDiseaseId",
                table: "MembersData",
                column: "KoronaDiseaseId",
                principalTable: "KoronaDiseasesData",
                principalColumn: "Id");
        }
    }
}
