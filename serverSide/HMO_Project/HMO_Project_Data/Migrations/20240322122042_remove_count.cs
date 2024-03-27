using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO_Project_Data.Migrations
{
    public partial class remove_count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VaccinesCount",
                table: "MembersData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VaccinesCount",
                table: "MembersData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
