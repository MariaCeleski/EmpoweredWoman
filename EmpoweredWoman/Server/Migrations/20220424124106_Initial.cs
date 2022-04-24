using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpoweredWoman.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperHeroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinancialBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperHeroes_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Developer" },
                    { 2, "Teacher" },
                    { 3, "Assistant" },
                    { 4, "Administrative" },
                    { 5, "Principal" }
                });

            migrationBuilder.InsertData(
                table: "SuperHeroes",
                columns: new[] { "Id", "Actions", "Company", "Country", "FinancialBank", "FirstName", "LastName", "PositionId" },
                values: new object[] { 1, "", "PrograMaria", "Brazil", "", "Maria", "Celeski", 1 });

            migrationBuilder.InsertData(
                table: "SuperHeroes",
                columns: new[] { "Id", "Actions", "Company", "Country", "FinancialBank", "FirstName", "LastName", "PositionId" },
                values: new object[] { 2, "", "PyLadies", "Brazil", "", "Jessica", "Matheus", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_PositionId",
                table: "SuperHeroes",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperHeroes");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
