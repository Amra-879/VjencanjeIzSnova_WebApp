using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VjencanjeIzSnova_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class DbMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "datum_vjenčanja",
                table: "Klijent",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "NULL",
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true,
                oldDefaultValueSql: "NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "datum_vjenčanja",
                table: "Klijent",
                type: "BLOB",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateOnly),
                oldType: "TEXT",
                oldDefaultValueSql: "NULL");
        }
    }
}
