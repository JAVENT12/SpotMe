using Microsoft.EntityFrameworkCore.Migrations;

namespace SpotMe_.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Excercisers",
                table: "Excercisers");

            migrationBuilder.DropColumn(
                name: "passWord",
                table: "Excercisers");

            migrationBuilder.RenameTable(
                name: "Excercisers",
                newName: "Excerciser");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Excerciser",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Excerciser",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Excerciser",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Excerciser",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userPassword",
                table: "Excerciser",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Excerciser",
                table: "Excerciser",
                column: "excerciserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Excerciser",
                table: "Excerciser");

            migrationBuilder.DropColumn(
                name: "userPassword",
                table: "Excerciser");

            migrationBuilder.RenameTable(
                name: "Excerciser",
                newName: "Excercisers");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Excercisers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Excercisers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Excercisers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Excercisers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "passWord",
                table: "Excercisers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Excercisers",
                table: "Excercisers",
                column: "excerciserID");
        }
    }
}
