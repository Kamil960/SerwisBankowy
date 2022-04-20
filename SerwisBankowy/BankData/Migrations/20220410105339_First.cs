using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankData.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Art1",
                columns: table => new
                {
                    IdArt1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Nazwa1 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Nazwa2 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Nazwa3 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Grafika1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grafika2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grafika3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grafika4 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Podsumowanie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art1", x => x.IdArt1);
                });

            migrationBuilder.CreateTable(
                name: "Art2",
                columns: table => new
                {
                    IdArt2 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Tresc1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Tresc2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Grafika = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art2", x => x.IdArt2);
                });

            migrationBuilder.CreateTable(
                name: "Art3",
                columns: table => new
                {
                    IdArt1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Tresc1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tresc2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PozGieldowa1 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PozGieldowa2 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PozGieldowa3 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PozGieldowa4 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Grafika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrypTytul = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Crypto1 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Crypto2 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Crypto3 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Crypto4 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CrypIcon1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrypIcon2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrypIcon3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrypIcon4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art3", x => x.IdArt1);
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miejscowosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrBudynku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Poczta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrDokumentu = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Kontakt",
                columns: table => new
                {
                    IdKontakt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis1 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Opis2 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Opis3 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Opis4 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrTelefonuSt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrTelefonuKom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakt", x => x.IdKontakt);
                });

            migrationBuilder.CreateTable(
                name: "ONas",
                columns: table => new
                {
                    IdONas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Grafika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ONas", x => x.IdONas);
                });

            migrationBuilder.CreateTable(
                name: "Strony",
                columns: table => new
                {
                    IdStrony = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strony", x => x.IdStrony);
                });

            migrationBuilder.CreateTable(
                name: "Usluga",
                columns: table => new
                {
                    IdUsluga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluga", x => x.IdUsluga);
                });

            migrationBuilder.CreateTable(
                name: "UslugaSzczegolowa",
                columns: table => new
                {
                    IdUslugaSzczegolowa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Procent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grafika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozycja = table.Column<int>(type: "int", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UslugaSzczegolowa", x => x.IdUslugaSzczegolowa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Art1");

            migrationBuilder.DropTable(
                name: "Art2");

            migrationBuilder.DropTable(
                name: "Art3");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Kontakt");

            migrationBuilder.DropTable(
                name: "ONas");

            migrationBuilder.DropTable(
                name: "Strony");

            migrationBuilder.DropTable(
                name: "Usluga");

            migrationBuilder.DropTable(
                name: "UslugaSzczegolowa");
        }
    }
}
