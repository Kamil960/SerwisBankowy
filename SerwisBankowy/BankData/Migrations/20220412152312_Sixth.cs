using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankData.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KontoFirmowe",
                columns: table => new
                {
                    IdUslugaSzczegolowa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsluga = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Grafika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozycja = table.Column<int>(type: "int", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontoFirmowe", x => x.IdUslugaSzczegolowa);
                });

            migrationBuilder.CreateTable(
                name: "KontoOsobiste",
                columns: table => new
                {
                    IdUslugaSzczegolowa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsluga = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Grafika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozycja = table.Column<int>(type: "int", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontoOsobiste", x => x.IdUslugaSzczegolowa);
                });

            migrationBuilder.CreateTable(
                name: "Kredyt",
                columns: table => new
                {
                    IdUslugaSzczegolowa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsluga = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Procent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grafika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozycja = table.Column<int>(type: "int", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kredyt", x => x.IdUslugaSzczegolowa);
                });

            migrationBuilder.CreateTable(
                name: "Lokata",
                columns: table => new
                {
                    IdUslugaSzczegolowa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsluga = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Procent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grafika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozycja = table.Column<int>(type: "int", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokata", x => x.IdUslugaSzczegolowa);
                });

            migrationBuilder.CreateTable(
                name: "Ubezpieczenie",
                columns: table => new
                {
                    IdUslugaSzczegolowa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsluga = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Grafika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozycja = table.Column<int>(type: "int", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubezpieczenie", x => x.IdUslugaSzczegolowa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KontoFirmowe");

            migrationBuilder.DropTable(
                name: "KontoOsobiste");

            migrationBuilder.DropTable(
                name: "Kredyt");

            migrationBuilder.DropTable(
                name: "Lokata");

            migrationBuilder.DropTable(
                name: "Ubezpieczenie");
        }
    }
}
