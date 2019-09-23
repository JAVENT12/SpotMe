using Microsoft.EntityFrameworkCore.Migrations;

namespace SpotMe_.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Excercisers",
                columns: table => new
                {
                    excerciserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    passWord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercisers", x => x.excerciserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Excercisers");
        }
    }
}
