using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VjencanjeIzSnova_WebApp.Models;
using VjencanjeIzSnova_WebApp.ViewModels;

namespace VjencanjeIzSnova_WebApp.Data;


public partial class VjencanjeIzSnovaDbContext : IdentityDbContext<Korisnik>
{
    private readonly IConfiguration _configuration;

    public VjencanjeIzSnovaDbContext(DbContextOptions<VjencanjeIzSnovaDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("VjencanjeIzSnovaDB");
            optionsBuilder.UseSqlite(connectionString);
        }
    }

    public virtual DbSet<Kategorije> Kategorije { get; set; }

    public virtual DbSet<Klijent> Klijenti { get; set; }

    public virtual DbSet<Korisnik> Korisnici { get; set; }

    public virtual DbSet<Košarica> Košarica { get; set; }

    public virtual DbSet<Partner> Partneri { get; set; }

    public virtual DbSet<Planer> Planeri { get; set; }

    public virtual DbSet<Transakcija> Plaćanja { get; set; }

    public virtual DbSet<Recenzija> Recenzije { get; set; }

    public virtual DbSet<Rezervacija> Rezervacije { get; set; }

    public virtual DbSet<Slike> Slike { get; set; }

    public virtual DbSet<Usluga> Usluge { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=VjencanjeIzSnovaDB.db");
   */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
        modelBuilder.Entity<PartnerViewModel>().HasNoKey();
        modelBuilder.Entity<UslugaViewModel>().HasNoKey();

        modelBuilder.Entity<Kategorije>(entity =>
        {
            entity.HasKey(e => e.KategorijaId);

            entity.ToTable("Kategorije");

            entity.Property(e => e.KategorijaId).HasColumnName("kategorija_id");
            entity.Property(e => e.Naziv)
                .HasColumnType("NVARCHAR(100)")
                .HasColumnName("naziv");
            entity.Property(e => e.Opis)
                .HasDefaultValueSql("NULL")
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("opis");
        });

        modelBuilder.Entity<Klijent>(entity =>
        {
            entity.ToTable("Klijent");

            entity.HasIndex(e => e.UserId, "UQ__Klijent__B9BE370E02949A1F")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.KlijentId).HasColumnName("klijent_id");
            entity.Property(e => e.DatumVjenčanja)
                .HasDefaultValueSql("NULL")
                .HasColumnName("datum_vjenčanja");
            entity.Property(e => e.Grad)
                .HasDefaultValueSql("NULL")
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("grad");
            entity.Property(e => e.Ime)
                .HasColumnType("NVARCHAR(100)")
                .HasColumnName("ime");
            entity.Property(e => e.Prezime)
                .HasColumnType("NVARCHAR(100)")
                .HasColumnName("prezime");
            entity.Property(e => e.UserId)
                .HasColumnType("INT")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Klijent)
                .HasForeignKey<Klijent>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {

            entity.ToTable("Korisnik");

        
           
            entity.Property(e => e.UserType)
                .HasColumnType("NVARCHAR(20)")
                .HasColumnName("user_type");
            entity.Property(e => e.UserType)
               .HasColumnType("NVARCHAR(10)")
               .HasColumnName("ProfilnaSlikaUrl");
        });

        modelBuilder.Entity<Košarica>(entity =>
        {
            entity.ToTable("Košarica");

            entity.Property(e => e.KošaricaId).HasColumnName("košarica_id");
            entity.Property(e => e.Cijena)
                .HasColumnType("FLOAT(10,2)")
                .HasColumnName("cijena");
            entity.Property(e => e.ClientId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("client_id");
            entity.Property(e => e.NazivArtikla)
                .HasColumnType("NVARCHAR(100)")
                .HasColumnName("naziv_artikla");

            entity.HasOne(d => d.Client).WithMany(p => p.Košarica).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.ToTable("Partner");

            entity.HasIndex(e => e.UserId, "UQ__Partner__B9BE370ECFCA0A5E")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.Ime)
                .HasColumnType("NVARCHAR(100)")
                .HasColumnName("ime");
            entity.Property(e => e.KategorijaId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("kategorija_id");
            entity.Property(e => e.Mobitel)
                .HasDefaultValueSql("NULL")
                .HasColumnType("NVARCHAR(15)")
                .HasColumnName("mobitel");
            entity.Property(e => e.UserId)
                .HasColumnType("INT")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Partneri).HasForeignKey(d => d.KategorijaId);

            entity.HasOne(d => d.User).WithOne(p => p.Partner)
                .HasForeignKey<Partner>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Planer>(entity =>
        {
            entity.ToTable("Planer");

            entity.HasIndex(e => e.UserId, "UQ__Planer__B9BE370EEF0010D4")
                .IsUnique()
                .IsDescending();

            entity.Property(e => e.PlanerId).HasColumnName("planer_id");
            entity.Property(e => e.BrTrenutnihKlijenata)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("br_trenutnih_klijenata");
            entity.Property(e => e.UserId)
                .HasColumnType("INT")
                .HasColumnName("user_id");
            entity.Property(e => e.ZoomMeetingLink)
                .HasDefaultValueSql("NULL")
                .HasColumnType("NVARCHAR(100)")
                .HasColumnName("zoom_meeting_link");

            entity.HasOne(d => d.User).WithOne(p => p.Planer)
                .HasForeignKey<Planer>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Klijenti).WithMany(p => p.Planeri)
                .UsingEntity<Dictionary<string, object>>(
                    "PlanerKlijenti",
                    r => r.HasOne<Klijent>().WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Planer>().WithMany()
                        .HasForeignKey("PlanerId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("PlanerId", "ClientId");
                        j.ToTable("PlanerKlijenti");
                        j.IndexerProperty<int>("PlanerId")
                            .HasColumnType("INT")
                            .HasColumnName("planer_id");
                        j.IndexerProperty<int>("ClientId")
                            .HasColumnType("INT")
                            .HasColumnName("client_id");
                    });
        });

        modelBuilder.Entity<Transakcija>(entity =>
        {
            entity.HasKey(e => e.PaymentId);

            entity.ToTable("Transakcija");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Iznos)
                .HasColumnType("FLOAT(10,2)")
                .HasColumnName("iznos");
            entity.Property(e => e.KlijentId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("klijent_id");
            entity.Property(e => e.PlacanjeDatum)
                .HasColumnType("DATETIME")
                .HasColumnName("placanje_datum");
            entity.Property(e => e.TransakcijaId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("NVARCHAR(100)")
                .HasColumnName("transakcija_id");

            entity.HasOne(d => d.Klijent).WithMany(p => p.Plaćanja).HasForeignKey(d => d.KlijentId);
        });

        modelBuilder.Entity<Recenzija>(entity =>
        {
            entity.HasKey(e => e.RecenzijaId);

            entity.ToTable("Recenzija");

            entity.Property(e => e.RecenzijaId).HasColumnName("recenzija_id");
            entity.Property(e => e.Datum).HasColumnName("datum");
            entity.Property(e => e.KlijentId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("klijent_id");
            entity.Property(e => e.Komentar)
                .HasDefaultValueSql("NULL")
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("komentar");
            entity.Property(e => e.Ocjena)
                .HasDefaultValueSql("NULL")
                .HasColumnType("FLOAT(53,0)")
                .HasColumnName("ocjena");
            entity.Property(e => e.UslugaId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("usluga_id");

            entity.HasOne(d => d.Klijent).WithMany(p => p.Recenzije).HasForeignKey(d => d.KlijentId);

            entity.HasOne(d => d.Usluga).WithMany(p => p.Recenzije).HasForeignKey(d => d.UslugaId);
        });

        modelBuilder.Entity<Rezervacija>(entity =>
        {
            entity.HasKey(e => e.RezervacijeId);

            entity.ToTable("Rezervacija");

            entity.Property(e => e.RezervacijeId).HasColumnName("rezervacije_id");
            entity.Property(e => e.Datum).HasColumnName("datum");
            entity.Property(e => e.KlijentId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("klijent_id");
            entity.Property(e => e.Status)
                .HasDefaultValue("pending")
                .HasColumnType("NVARCHAR(20)")
                .HasColumnName("status");
            entity.Property(e => e.UslugaId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("usluga_id");

            entity.HasOne(d => d.Klijent).WithMany(p => p.Rezervacije).HasForeignKey(d => d.KlijentId);

            entity.HasOne(d => d.Usluga).WithMany(p => p.Rezervacije).HasForeignKey(d => d.UslugaId);
        });

        modelBuilder.Entity<Slike>(entity =>
        {
            entity.HasKey(e => e.Url);

            entity.ToTable("Slike");

            entity.HasOne(d => d.Usluga).WithMany(p => p.Slike)
                .HasForeignKey(d => d.UslugaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Usluga>(entity =>
        {
            entity.ToTable("Usluga");

            entity.HasIndex(e => e.KategorijaId, "IX_Usluge_KategorijaId");

            entity.HasIndex(e => e.PartnerId, "IX_Usluge_partner_id");

            entity.Property(e => e.UslugaId).HasColumnName("usluga_id");
            entity.Property(e => e.CjenovniRang).HasColumnName("cjenovniRang");
            entity.Property(e => e.Detalji).HasColumnName("detalji");
            entity.Property(e => e.InfoOKompaniji).HasColumnName("infoOKompaniji");
            entity.Property(e => e.Naziv).HasColumnName("naziv");
            entity.Property(e => e.Opis).HasColumnName("opis");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Usluge).HasForeignKey(d => d.KategorijaId);

            entity.HasOne(d => d.Partner).WithMany(p => p.Usluge).HasForeignKey(d => d.PartnerId);
        });

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<VjencanjeIzSnova_WebApp.ViewModels.PartnerViewModel> PartnerViewModel { get; set; } = default!;

}
