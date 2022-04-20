using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankData.Migrations
{
    public partial class Eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nazwa",
                table: "Art3");

            migrationBuilder.DropColumn(
                name: "Grafika4",
                table: "Art1");

            migrationBuilder.RenameColumn(
                name: "IdArt1",
                table: "Art3",
                newName: "IdArt3");

            migrationBuilder.AlterColumn<string>(
                name: "Grafika",
                table: "Art3",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdArt3",
                table: "Art3",
                newName: "IdArt1");

            migrationBuilder.AlterColumn<string>(
                name: "Grafika",
                table: "Art3",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Nazwa",
                table: "Art3",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Grafika4",
                table: "Art1",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
