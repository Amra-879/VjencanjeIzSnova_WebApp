using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VjencanjeIzSnova_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    kategorija_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naziv = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    opis = table.Column<string>(type: "NVARCHAR(50)", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.kategorija_id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    user_type = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    ProfilnaSlikaUrl = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    klijent_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<string>(type: "INT", nullable: false),
                    ime = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    prezime = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    grad = table.Column<string>(type: "NVARCHAR(50)", nullable: true, defaultValueSql: "NULL"),
                    datum_vjenčanja = table.Column<byte[]>(type: "BLOB", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.klijent_id);
                    table.ForeignKey(
                        name: "FK_Klijent_Korisnik_user_id",
                        column: x => x.user_id,
                        principalTable: "Korisnik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    partner_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<string>(type: "INT", nullable: false),
                    ime = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    mobitel = table.Column<string>(type: "NVARCHAR(15)", nullable: true, defaultValueSql: "NULL"),
                    kategorija_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.partner_id);
                    table.ForeignKey(
                        name: "FK_Partner_Kategorije_kategorija_id",
                        column: x => x.kategorija_id,
                        principalTable: "Kategorije",
                        principalColumn: "kategorija_id");
                    table.ForeignKey(
                        name: "FK_Partner_Korisnik_user_id",
                        column: x => x.user_id,
                        principalTable: "Korisnik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Planer",
                columns: table => new
                {
                    planer_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<string>(type: "INT", nullable: false),
                    br_trenutnih_klijenata = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    zoom_meeting_link = table.Column<string>(type: "NVARCHAR(100)", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planer", x => x.planer_id);
                    table.ForeignKey(
                        name: "FK_Planer_Korisnik_user_id",
                        column: x => x.user_id,
                        principalTable: "Korisnik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Košarica",
                columns: table => new
                {
                    košarica_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    client_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    naziv_artikla = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    cijena = table.Column<double>(type: "FLOAT(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Košarica", x => x.košarica_id);
                    table.ForeignKey(
                        name: "FK_Košarica_Klijent_client_id",
                        column: x => x.client_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                });

            migrationBuilder.CreateTable(
                name: "Transakcija",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    klijent_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    iznos = table.Column<double>(type: "FLOAT(10,2)", nullable: false),
                    placanje_datum = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    transakcija_id = table.Column<string>(type: "NVARCHAR(100)", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcija", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_Transakcija_Klijent_klijent_id",
                        column: x => x.klijent_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    recenzija_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    klijent_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    usluga_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    ocjena = table.Column<double>(type: "FLOAT(53,0)", nullable: true, defaultValueSql: "NULL"),
                    komentar = table.Column<string>(type: "NVARCHAR(50)", nullable: true, defaultValueSql: "NULL"),
                    datum = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.recenzija_id);
                    table.ForeignKey(
                        name: "FK_Recenzija_Klijent_klijent_id",
                        column: x => x.klijent_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                    table.ForeignKey(
                        name: "FK_Recenzija_Partner_usluga_id",
                        column: x => x.usluga_id,
                        principalTable: "Partner",
                        principalColumn: "partner_id");
                });

            migrationBuilder.CreateTable(
                name: "Usluga",
                columns: table => new
                {
                    usluga_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KategorijaId = table.Column<int>(type: "INTEGER", nullable: false),
                    KontaktMail = table.Column<string>(type: "TEXT", nullable: false),
                    cjenovniRang = table.Column<string>(type: "TEXT", nullable: true),
                    detalji = table.Column<string>(type: "TEXT", nullable: false),
                    infoOKompaniji = table.Column<string>(type: "TEXT", nullable: false),
                    naziv = table.Column<string>(type: "TEXT", nullable: false),
                    opis = table.Column<string>(type: "TEXT", nullable: true),
                    partner_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluga", x => x.usluga_id);
                    table.ForeignKey(
                        name: "FK_Usluga_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "kategorija_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usluga_Partner_partner_id",
                        column: x => x.partner_id,
                        principalTable: "Partner",
                        principalColumn: "partner_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanerKlijenti",
                columns: table => new
                {
                    planer_id = table.Column<int>(type: "INT", nullable: false),
                    client_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanerKlijenti", x => new { x.planer_id, x.client_id });
                    table.ForeignKey(
                        name: "FK_PlanerKlijenti_Klijent_client_id",
                        column: x => x.client_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                    table.ForeignKey(
                        name: "FK_PlanerKlijenti_Planer_planer_id",
                        column: x => x.planer_id,
                        principalTable: "Planer",
                        principalColumn: "planer_id");
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    rezervacije_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    klijent_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    usluga_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "NULL"),
                    datum = table.Column<byte[]>(type: "BLOB", nullable: false),
                    status = table.Column<string>(type: "NVARCHAR(20)", nullable: true, defaultValue: "pending")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.rezervacije_id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Klijent_klijent_id",
                        column: x => x.klijent_id,
                        principalTable: "Klijent",
                        principalColumn: "klijent_id");
                    table.ForeignKey(
                        name: "FK_Rezervacija_Usluga_usluga_id",
                        column: x => x.usluga_id,
                        principalTable: "Usluga",
                        principalColumn: "usluga_id");
                });

            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    SlikaId = table.Column<int>(type: "INTEGER", nullable: false),
                    UslugaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slike", x => x.Url);
                    table.ForeignKey(
                        name: "FK_Slike_Usluga_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluga",
                        principalColumn: "usluga_id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Klijent__B9BE370E02949A1F",
                table: "Klijent",
                column: "user_id",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Košarica_client_id",
                table: "Košarica",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_kategorija_id",
                table: "Partner",
                column: "kategorija_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Partner__B9BE370ECFCA0A5E",
                table: "Partner",
                column: "user_id",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "UQ__Planer__B9BE370EEF0010D4",
                table: "Planer",
                column: "user_id",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_PlanerKlijenti_client_id",
                table: "PlanerKlijenti",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_klijent_id",
                table: "Recenzija",
                column: "klijent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_usluga_id",
                table: "Recenzija",
                column: "usluga_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_klijent_id",
                table: "Rezervacija",
                column: "klijent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_usluga_id",
                table: "Rezervacija",
                column: "usluga_id");

            migrationBuilder.CreateIndex(
                name: "IX_Slike_UslugaId",
                table: "Slike",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_klijent_id",
                table: "Transakcija",
                column: "klijent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_KategorijaId",
                table: "Usluga",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_partner_id",
                table: "Usluga",
                column: "partner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Košarica");

            migrationBuilder.DropTable(
                name: "PlanerKlijenti");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Slike");

            migrationBuilder.DropTable(
                name: "Transakcija");

            migrationBuilder.DropTable(
                name: "Planer");

            migrationBuilder.DropTable(
                name: "Usluga");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
