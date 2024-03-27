using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO_Project_Data.Migrations
{
    public partial class add_count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VaccinesCount",
                table: "MembersData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VaccinesCount",
                table: "MembersData");
        }
    }
}
