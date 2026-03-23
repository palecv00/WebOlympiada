using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOlympiada.Data.Migrations
{
    /// <inheritdoc />
    public partial class MilosBigFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Sports",
                newName: "Sport");

            migrationBuilder.CreateTable(
                name: "Divaci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prijmeni = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Divaci__3214EC072BFDF6C1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rozhodci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sport = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rozhodc__3214EC07B9C8F1B7", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sportovec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Narodnost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sportove__3214EC07B9C8F1B7", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Divaci");

            migrationBuilder.DropTable(
                name: "Rozhodci");

            migrationBuilder.DropTable(
                name: "Sportovec");

            migrationBuilder.RenameTable(
                name: "Sport",
                newName: "Sports");
        }
    }
}
