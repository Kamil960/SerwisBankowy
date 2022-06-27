using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankData.Migrations
{
    public partial class M9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CzyAktywna",
                table: "Koszyk",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grafika",
                table: "Koszyk",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kategoria",
                table: "Koszyk",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LiczbaPunktow",
                table: "Koszyk",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nazwa",
                table: "Koszyk",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CzyAktywna",
                table: "Koszyk");

            migrationBuilder.DropColumn(
                name: "Grafika",
                table: "Koszyk");

            migrationBuilder.DropColumn(
                name: "Kategoria",
                table: "Koszyk");

            migrationBuilder.DropColumn(
                name: "LiczbaPunktow",
                table: "Koszyk");

            migrationBuilder.DropColumn(
                name: "Nazwa",
                table: "Koszyk");
        }
    }
}
