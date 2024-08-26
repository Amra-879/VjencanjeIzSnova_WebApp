using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VjencanjeIzSnova_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ModelChanges3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartnerViewModel",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false),
                    Ime = table.Column<string>(type: "TEXT", nullable: false),
                    Mobitel = table.Column<string>(type: "TEXT", nullable: true),
                    KategorijaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UslugaViewModel",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Naziv = table.Column<string>(type: "TEXT", nullable: false),
                    OpisUsluge = table.Column<string>(type: "TEXT", nullable: false),
                    CjenovniRang = table.Column<string>(type: "TEXT", nullable: false),
                    InfoOKompaniji = table.Column<string>(type: "TEXT", nullable: false),
                    Detalji = table.Column<string>(type: "TEXT", nullable: false),
                    KontaktMail = table.Column<string>(type: "TEXT", nullable: false),
                    SlikaId = table.Column<int>(type: "INTEGER", nullable: false),
                    UslugaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    KategorijaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_UslugaViewModel_Partner_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "partner_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UslugaViewModel_Usluga_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluga",
                        principalColumn: "usluga_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UslugaViewModel_PartnerId",
                table: "UslugaViewModel",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UslugaViewModel_UslugaId",
                table: "UslugaViewModel",
                column: "UslugaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerViewModel");

            migrationBuilder.DropTable(
                name: "UslugaViewModel");
        }
    }
}
