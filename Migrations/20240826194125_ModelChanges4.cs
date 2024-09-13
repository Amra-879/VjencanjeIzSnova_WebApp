using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VjencanjeIzSnova_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ModelChanges4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Usluga",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Usluga",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "Usluga",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "Usluga",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteLink",
                table: "Usluga",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OmiljeneStavke",
                columns: table => new
                {
                    KlijentId = table.Column<int>(type: "INTEGER", nullable: false),
                    UslugaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OmiljeneStavke", x => new { x.KlijentId, x.UslugaId });
                    table.ForeignKey(
                        name: "FK_OmiljeneStavke_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OmiljeneStavke_Usluga_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluga",
                        principalColumn: "usluga_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_Omiljeno",
                table: "OmiljeneStavke",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluga_Omiljeno",
                table: "OmiljeneStavke",
                column: "UslugaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OmiljeneStavke");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Usluga");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Usluga");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "Usluga");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "Usluga");

            migrationBuilder.DropColumn(
                name: "WebsiteLink",
                table: "Usluga");

            migrationBuilder.RenameColumn(
                name: "Opis",
                table: "UslugaViewModel",
                newName: "OpisUsluge");
        }
    }
}
