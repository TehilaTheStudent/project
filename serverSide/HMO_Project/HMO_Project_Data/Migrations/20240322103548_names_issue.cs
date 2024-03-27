using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO_Project_Data.Migrations
{
    public partial class names_issue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "recieveDate",
                table: "VaccinationsData",
                newName: "RecieveDate");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "MembersData",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "MembersData",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "mobilePhoneNumber",
                table: "MembersData",
                newName: "MobilePhoneNumber");

            migrationBuilder.RenameColumn(
                name: "idNumber",
                table: "MembersData",
                newName: "IdNumber");

            migrationBuilder.RenameColumn(
                name: "houseNumber",
                table: "MembersData",
                newName: "HouseNumber");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "MembersData",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "MembersData",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "birthDate",
                table: "MembersData",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "recovery",
                table: "KoronaDiseasesData",
                newName: "RecoveryDate");

            migrationBuilder.RenameColumn(
                name: "diagnosis",
                table: "KoronaDiseasesData",
                newName: "DiagnosisDate");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfVaccination",
                table: "VaccinationsData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfVaccination",
                table: "VaccinationsData");

            migrationBuilder.RenameColumn(
                name: "RecieveDate",
                table: "VaccinationsData",
                newName: "recieveDate");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "MembersData",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "MembersData",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "MobilePhoneNumber",
                table: "MembersData",
                newName: "mobilePhoneNumber");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "MembersData",
                newName: "idNumber");

            migrationBuilder.RenameColumn(
                name: "HouseNumber",
                table: "MembersData",
                newName: "houseNumber");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "MembersData",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "MembersData",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "MembersData",
                newName: "birthDate");

            migrationBuilder.RenameColumn(
                name: "RecoveryDate",
                table: "KoronaDiseasesData",
                newName: "recovery");

            migrationBuilder.RenameColumn(
                name: "DiagnosisDate",
                table: "KoronaDiseasesData",
                newName: "diagnosis");
        }
    }
}
