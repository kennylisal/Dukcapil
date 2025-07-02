using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<Orang> Orang { get; set; }

    public DbSet<Ktp> Ktp { get; set; }

    public DbSet<AktaKelahiran> AktaKelahiran { get; set; }

    public DbSet<AnggotaKartuKeluarga> AnggotaKartuKeluarga { get; set; }

    public DbSet<KartuKeluarga> KartuKeluarga { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Orang>().Property(o => o.Kewarganegaraan).HasConversion<string>();

        modelBuilder
            .Entity<Ktp>()
            .HasOne(k => k.Orang)
            .WithOne(o => o.Ktp)
            .HasForeignKey<Ktp>(k => k.Nik)
            // .OnDelete(DeleteBehavior.Cascade)
        ;

        modelBuilder
            .Entity<AktaKelahiran>()
            .HasOne(a => a.Orang)
            .WithOne(o => o.AktaKelahiran)
            .HasForeignKey<AktaKelahiran>(a => a.Nik)
            // .OnDelete(DeleteBehavior.Cascade)
        ;

        modelBuilder
            .Entity<AktaKelahiran>()
            .HasOne(a => a.Ayah)
            .WithMany()
            .HasForeignKey(a => a.NikAyah)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder
            .Entity<AktaKelahiran>()
            .HasOne(a => a.Ibu)
            .WithMany()
            .HasForeignKey(a => a.NikIbu)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder
            .Entity<AnggotaKartuKeluarga>()
            .HasOne(ak => ak.KartuKeluarga)
            .WithMany(kk => kk.AnggotaKartuKeluargas)
            .HasForeignKey(kk => kk.KartuKeluargaId);
        //ini diatas tampkanya untuk bikin composite key

        modelBuilder
            .Entity<AnggotaKartuKeluarga>()
            .HasOne(ak => ak.Orang)
            .WithOne(o => o.AnggotaKartuKeluarga)
            .HasForeignKey<AnggotaKartuKeluarga>(ak => ak.Nik);

        modelBuilder.Entity<AnggotaKartuKeluarga>().HasIndex(km => km.Nik).IsUnique(); // Ensures one KK per person

        modelBuilder
            .Entity<AnggotaKartuKeluarga>()
            .HasKey(ak => new { ak.KartuKeluargaId, ak.Nik });
        //haskey dan yang seperti ini, hanya boleh int atau string

        modelBuilder
            .Entity<KartuKeluarga>()
            .HasOne(kk => kk.Kepala_Keluarga)
            .WithOne(o => o.KartuKeluargaSeabagaiKepala)
            .HasForeignKey<KartuKeluarga>(kk => kk.Nik_kepala_keluarga)
            .OnDelete(DeleteBehavior.Restrict);

        //tambahan auto-generated dibawah

        modelBuilder.Entity<Ktp>(entity =>
        {
            entity.HasKey(e => e.Ktp_id);
            entity.Property(e => e.Ktp_id).ValueGeneratedOnAdd();
            entity.Property(e => e.Is_active).HasDefaultValue(true);
        });

        modelBuilder.Entity<AktaKelahiran>(entity =>
        {
            entity.HasKey(e => e.AktaKelahiran_id);
            entity.Property(e => e.AktaKelahiran_id).ValueGeneratedOnAdd();
            entity.Property(e => e.Is_active).HasDefaultValue(true);
        });
    }
}
