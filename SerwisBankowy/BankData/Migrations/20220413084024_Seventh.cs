using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankData.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
              name: "Tytul",
              table: "Art1",
              type: "nvarchar(50)",
              maxLength: 50,
              nullable: true,
              oldClrType: typeof(string),
              oldType: "nvarchar(32)",
              oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
              name: "Nazwa1",
              table: "Art1",
              type: "nvarchar(50)",
              maxLength: 50,
              nullable: true,
              oldClrType: typeof(string),
              oldType: "nvarchar(32)",
              oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
             name: "Nazwa2",
             table: "Art1",
             type: "nvarchar(50)",
             maxLength: 50,
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(32)",
             oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
             name: "Nazwa3",
             table: "Art1",
             type: "nvarchar(50)",
             maxLength: 50,
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(32)",
             oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
             name: "Grafika1",
             table: "Art1",
             type: "nvarchar(max)",
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(150)",
             oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
            name: "Grafika2",
            table: "Art1",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(150)",
            oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
            name: "Grafika3",
            table: "Art1",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(150)",
            oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
            name: "Grafika4",
            table: "Art1",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(150)",
            oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
             name: "Opis1",
             table: "Art1",
             type: "nvarchar(250)",
             maxLength: 250,
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(50)",
             oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
             name: "Opis2",
             table: "Art1",
             type: "nvarchar(250)",
             maxLength: 250,
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(50)",
             oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
             name: "Opis3",
             table: "Art1",
             type: "nvarchar(250)",
             maxLength: 250,
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(50)",
             oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
             name: "Podsumowanie",
             table: "Art1",
             type: "nvarchar(300)",
             maxLength: 300,
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(150)",
             oldMaxLength: 150);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
