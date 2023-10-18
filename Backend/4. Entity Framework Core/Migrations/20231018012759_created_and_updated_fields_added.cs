using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4._Entity_Framework_Core.Migrations
{
    /// <inheritdoc />
    public partial class created_and_updated_fields_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAdaugarii",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "DataUltimeiModificari",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "DataAdaugarii",
                table: "Persoane");

            migrationBuilder.DropColumn(
                name: "DataUltimeiModificari",
                table: "Persoane");

            migrationBuilder.DropColumn(
                name: "DataAdaugarii",
                table: "ComenziProduse");

            migrationBuilder.DropColumn(
                name: "DataUltimeiModificari",
                table: "ComenziProduse");

            migrationBuilder.DropColumn(
                name: "DataAdaugarii",
                table: "Comenzi");

            migrationBuilder.DropColumn(
                name: "DataUltimeiModificari",
                table: "Comenzi");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Produse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Produse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Persoane",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Persoane",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ComenziProduse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ComenziProduse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Comenzi",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comenzi",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Persoane");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Persoane");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ComenziProduse");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ComenziProduse");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Comenzi");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Comenzi");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdaugarii",
                table: "Produse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimeiModificari",
                table: "Produse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdaugarii",
                table: "Persoane",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimeiModificari",
                table: "Persoane",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdaugarii",
                table: "ComenziProduse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimeiModificari",
                table: "ComenziProduse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdaugarii",
                table: "Comenzi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimeiModificari",
                table: "Comenzi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
