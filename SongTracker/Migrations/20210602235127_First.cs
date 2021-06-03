using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectName.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Songs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tuning",
                table: "Songs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Instruments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Tuning",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Instruments");
        }
    }
}
