using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankData.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LiczbaPunktow",
                table: "Ubezpieczenie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiczbaPunktow",
                table: "Lokata",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiczbaPunktow",
                table: "Kredyt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiczbaPunktow",
                table: "KontoOsobiste",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiczbaPunktow",
                table: "KontoFirmowe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiczbaPunktow",
                table: "Klient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiczbaPunktow",
                table: "Ubezpieczenie");

            migrationBuilder.DropColumn(
                name: "LiczbaPunktow",
                table: "Lokata");

            migrationBuilder.DropColumn(
                name: "LiczbaPunktow",
                table: "Kredyt");

            migrationBuilder.DropColumn(
                name: "LiczbaPunktow",
                table: "KontoOsobiste");

            migrationBuilder.DropColumn(
                name: "LiczbaPunktow",
                table: "KontoFirmowe");

            migrationBuilder.DropColumn(
                name: "LiczbaPunktow",
                table: "Klient");
        }
    }
}
