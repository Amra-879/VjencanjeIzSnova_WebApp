﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VjencanjeIzSnova_WebApp.Data;

#nullable disable

namespace VjencanjeIzSnova_WebApp.Migrations
{
    [DbContext(typeof(VjencanjeIzSnovaDbContext))]
    partial class VjencanjeIzSnovaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("PlanerKlijenti", b =>
                {
                    b.Property<int>("PlanerId")
                        .HasColumnType("INT")
                        .HasColumnName("planer_id");

                    b.Property<int>("ClientId")
                        .HasColumnType("INT")
                        .HasColumnName("client_id");

                    b.HasKey("PlanerId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("PlanerKlijenti", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Kategorije", b =>
                {
                    b.Property<int>("KategorijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("kategorija_id");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("naziv");

                    b.Property<string>("Opis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)")
                        .HasColumnName("opis")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("KategorijaId");

                    b.ToTable("Kategorije", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Klijent", b =>
                {
                    b.Property<int>("KlijentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("klijent_id");

                    b.Property<DateOnly>("DatumVjenčanja")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("datum_vjenčanja")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Grad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)")
                        .HasColumnName("grad")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("ime");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("prezime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("user_id");

                    b.HasKey("KlijentId");

                    b.HasIndex(new[] { "UserId" }, "UQ__Klijent__B9BE370E02949A1F")
                        .IsUnique()
                        .IsDescending();

                    b.ToTable("Klijent", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Korisnik", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfilnaSlikaUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("ProfilnaSlikaUrl");

                    b.HasKey("Id");

                    b.ToTable("Korisnik", null, t =>
                        {
                            t.Property("ProfilnaSlikaUrl")
                                .HasColumnName("ProfilnaSlikaUrl");
                        });
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Košarica", b =>
                {
                    b.Property<int>("KošaricaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("košarica_id");

                    b.Property<double>("Cijena")
                        .HasColumnType("FLOAT(10,2)")
                        .HasColumnName("cijena");

                    b.Property<int?>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("client_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("NazivArtikla")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("naziv_artikla");

                    b.HasKey("KošaricaId");

                    b.HasIndex("ClientId");

                    b.ToTable("Košarica", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.OmiljeneStavke", b =>
                {
                    b.Property<int>("KlijentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("KlijentId");

                    b.Property<int>("UslugaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("UslugaId");

                    b.HasKey("KlijentId", "UslugaId");

                    b.HasIndex(new[] { "KlijentId" }, "IX_Klijent_Omiljeno");

                    b.HasIndex(new[] { "UslugaId" }, "IX_Usluga_Omiljeno");

                    b.ToTable("OmiljeneStavke", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Partner", b =>
                {
                    b.Property<int>("PartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("partner_id");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("ime");

                    b.Property<int?>("KategorijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("kategorija_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Mobitel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(15)")
                        .HasColumnName("mobitel")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("user_id");

                    b.HasKey("PartnerId");

                    b.HasIndex("KategorijaId");

                    b.HasIndex(new[] { "UserId" }, "UQ__Partner__B9BE370ECFCA0A5E")
                        .IsUnique()
                        .IsDescending();

                    b.ToTable("Partner", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Planer", b =>
                {
                    b.Property<int>("PlanerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("planer_id");

                    b.Property<int?>("BrTrenutnihKlijenata")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("br_trenutnih_klijenata")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("user_id");

                    b.Property<string>("ZoomMeetingLink")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("zoom_meeting_link")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("PlanerId");

                    b.HasIndex(new[] { "UserId" }, "UQ__Planer__B9BE370EEF0010D4")
                        .IsUnique()
                        .IsDescending();

                    b.ToTable("Planer", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Recenzija", b =>
                {
                    b.Property<int>("RecenzijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("recenzija_id");

                    b.Property<byte[]>("Datum")
                        .IsRequired()
                        .HasColumnType("BLOB")
                        .HasColumnName("datum");

                    b.Property<int?>("KlijentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("klijent_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Komentar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)")
                        .HasColumnName("komentar")
                        .HasDefaultValueSql("NULL");

                    b.Property<double?>("Ocjena")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("FLOAT(53,0)")
                        .HasColumnName("ocjena")
                        .HasDefaultValueSql("NULL");

                    b.Property<int?>("UslugaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("usluga_id")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("RecenzijaId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("UslugaId");

                    b.ToTable("Recenzija", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("rezervacije_id");

                    b.Property<byte[]>("Datum")
                        .IsRequired()
                        .HasColumnType("BLOB")
                        .HasColumnName("datum");

                    b.Property<int?>("KlijentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("klijent_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(20)")
                        .HasDefaultValue("pending")
                        .HasColumnName("status");

                    b.Property<int?>("UslugaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("usluga_id")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("RezervacijeId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("UslugaId");

                    b.ToTable("Rezervacija", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Slike", b =>
                {
                    b.Property<string>("Url")
                        .HasColumnType("TEXT")
                        .HasColumnName("Url");

                    b.Property<int>("SlikaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("SlikaId");

                    b.Property<int>("UslugaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("UslugaId");

                    b.HasKey("Url");

                    b.HasIndex("UslugaId");

                    b.ToTable("Slike", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Transakcija", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("payment_id");

                    b.Property<double>("Iznos")
                        .HasColumnType("FLOAT(10,2)")
                        .HasColumnName("iznos");

                    b.Property<int?>("KlijentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("klijent_id")
                        .HasDefaultValueSql("NULL");

                    b.Property<DateTime>("PlacanjeDatum")
                        .HasColumnType("DATETIME")
                        .HasColumnName("placanje_datum");

                    b.Property<string>("TransakcijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("transakcija_id")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("PaymentId");

                    b.HasIndex("KlijentId");

                    b.ToTable("Transakcija", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Usluga", b =>
                {
                    b.Property<int>("UslugaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("usluga_id");

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Adresa");

                    b.Property<string>("CjenovniRang")
                        .HasColumnType("TEXT")
                        .HasColumnName("cjenovniRang");

                    b.Property<string>("Detalji")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("detalji");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("TEXT")
                        .HasColumnName("FacebookLink");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Grad");

                    b.Property<string>("InfoOKompaniji")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("infoOKompaniji");

                    b.Property<string>("InsragramLink")
                        .HasColumnType("TEXT")
                        .HasColumnName("InstagramLink");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KontaktMail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("naziv");

                    b.Property<string>("Opis")
                        .HasColumnType("TEXT")
                        .HasColumnName("opis");

                    b.Property<int>("PartnerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("partner_id");

                    b.Property<string>("WebsiteLink")
                        .HasColumnType("TEXT")
                        .HasColumnName("WebsiteLink");

                    b.HasKey("UslugaId");

                    b.HasIndex(new[] { "KategorijaId" }, "IX_Usluge_KategorijaId");

                    b.HasIndex(new[] { "PartnerId" }, "IX_Usluge_partner_id");

                    b.ToTable("Usluga", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.ViewModels.PartnerViewModel", b =>
                {
                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mobitel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("PartnerViewModel", (string)null);
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.ViewModels.UslugaViewModel", b =>
                {
                    b.Property<string>("CjenovniRang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Detalji")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InfoOKompaniji")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("KategorijaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KontaktMail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PartnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SlikaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UslugaId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("PartnerId");

                    b.HasIndex("UslugaId");

                    b.ToTable("UslugaViewModel", (string)null);
                });

            modelBuilder.Entity("PlanerKlijenti", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Klijent", null)
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .IsRequired();

                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Planer", null)
                        .WithMany()
                        .HasForeignKey("PlanerId")
                        .IsRequired();
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Klijent", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Korisnik", "User")
                        .WithOne("Klijent")
                        .HasForeignKey("VjencanjeIzSnova_WebApp.Models.Klijent", "UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Košarica", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Klijent", "Client")
                        .WithMany("Košarica")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.OmiljeneStavke", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Klijent", "klijent")
                        .WithMany("Omiljeno")
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Usluga", "usluga")
                        .WithMany("FavoritedBy")
                        .HasForeignKey("UslugaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("klijent");

                    b.Navigation("usluga");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Partner", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Kategorije", "Kategorija")
                        .WithMany("Partneri")
                        .HasForeignKey("KategorijaId");

                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Korisnik", "User")
                        .WithOne("Partner")
                        .HasForeignKey("VjencanjeIzSnova_WebApp.Models.Partner", "UserId")
                        .IsRequired();

                    b.Navigation("Kategorija");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Planer", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Korisnik", "User")
                        .WithOne("Planer")
                        .HasForeignKey("VjencanjeIzSnova_WebApp.Models.Planer", "UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Recenzija", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Klijent", "Klijent")
                        .WithMany("Recenzije")
                        .HasForeignKey("KlijentId");

                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Partner", "Usluga")
                        .WithMany("Recenzije")
                        .HasForeignKey("UslugaId");

                    b.Navigation("Klijent");

                    b.Navigation("Usluga");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Rezervacija", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Klijent", "Klijent")
                        .WithMany("Rezervacije")
                        .HasForeignKey("KlijentId");

                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Usluga", "Usluga")
                        .WithMany("Rezervacije")
                        .HasForeignKey("UslugaId");

                    b.Navigation("Klijent");

                    b.Navigation("Usluga");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Slike", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Usluga", "Usluga")
                        .WithMany("Slike")
                        .HasForeignKey("UslugaId")
                        .IsRequired();

                    b.Navigation("Usluga");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Transakcija", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Klijent", "Klijent")
                        .WithMany("Plaćanja")
                        .HasForeignKey("KlijentId");

                    b.Navigation("Klijent");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Usluga", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Kategorije", "Kategorija")
                        .WithMany("Usluge")
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Partner", "Partner")
                        .WithMany("Usluge")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorija");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.ViewModels.UslugaViewModel", b =>
                {
                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VjencanjeIzSnova_WebApp.Models.Usluga", "Usluga")
                        .WithMany()
                        .HasForeignKey("UslugaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");

                    b.Navigation("Usluga");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Kategorije", b =>
                {
                    b.Navigation("Partneri");

                    b.Navigation("Usluge");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Klijent", b =>
                {
                    b.Navigation("Košarica");

                    b.Navigation("Omiljeno");

                    b.Navigation("Plaćanja");

                    b.Navigation("Recenzije");

                    b.Navigation("Rezervacije");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Korisnik", b =>
                {
                    b.Navigation("Klijent");

                    b.Navigation("Partner");

                    b.Navigation("Planer");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Partner", b =>
                {
                    b.Navigation("Recenzije");

                    b.Navigation("Usluge");
                });

            modelBuilder.Entity("VjencanjeIzSnova_WebApp.Models.Usluga", b =>
                {
                    b.Navigation("FavoritedBy");

                    b.Navigation("Rezervacije");

                    b.Navigation("Slike");
                });
#pragma warning restore 612, 618
        }
    }
}
