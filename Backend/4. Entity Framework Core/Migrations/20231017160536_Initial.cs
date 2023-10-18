using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4._Entity_Framework_Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    ComandaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersoanaID = table.Column<int>(type: "int", nullable: false),
                    DataAdaugarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimeiModificari = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.ComandaID);
                });

            migrationBuilder.CreateTable(
                name: "ComenziProduse",
                columns: table => new
                {
                    ComandaID = table.Column<int>(type: "int", nullable: false),
                    ProdusID = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    DataAdaugarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimeiModificari = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComenziProduse", x => new { x.ComandaID, x.ProdusID });
                });

            migrationBuilder.CreateTable(
                name: "Persoane",
                columns: table => new
                {
                    PersoanaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAdaugarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimeiModificari = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persoane", x => x.PersoanaID);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    ProdusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProdus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAdaugarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimeiModificari = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.ProdusID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "ComenziProduse");

            migrationBuilder.DropTable(
                name: "Persoane");

            migrationBuilder.DropTable(
                name: "Produse");
        }
    }
}
