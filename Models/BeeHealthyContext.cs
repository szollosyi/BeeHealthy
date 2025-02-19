using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bee_healthy_backend.Models;

public partial class BeeHealthyContext : DbContext
{
    public BeeHealthyContext()
    {
    }

    public BeeHealthyContext(DbContextOptions<BeeHealthyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gyarto> Gyartos { get; set; }

    public virtual DbSet<GyogyszerAdatok> GyogyszerAdatoks { get; set; }

    public virtual DbSet<Orvosok> Orvosoks { get; set; }

    public virtual DbSet<Paciensek> Pacienseks { get; set; }

    public virtual DbSet<Receptek> Recepteks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=bee_healthy;USER=root;PASSWORD=;SSL MODE=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gyarto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gyarto");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cim).HasMaxLength(64);
            entity.Property(e => e.Leiras).HasColumnType("text");
            entity.Property(e => e.Nev).HasMaxLength(64);
        });

        modelBuilder.Entity<GyogyszerAdatok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gyogyszer_adatok");

            entity.HasIndex(e => e.GyartoId, "GyartoId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Adagolas).HasMaxLength(64);
            entity.Property(e => e.Emlekezteto).HasColumnType("date");
            entity.Property(e => e.GyartoId).HasColumnType("int(11)");
            entity.Property(e => e.GyogyszerNev)
                .HasMaxLength(64)
                .HasColumnName("Gyogyszer_nev");
            entity.Property(e => e.Kategoria).HasMaxLength(64);
            entity.Property(e => e.KezelesKezdete).HasColumnType("date");
            entity.Property(e => e.KezelesVege).HasColumnType("date");
            entity.Property(e => e.KezelesiIdopont)
                .HasMaxLength(64)
                .HasColumnName("Kezelesi_idopont");
            entity.Property(e => e.Megjegyzes).HasMaxLength(100);

            entity.HasOne(d => d.Gyarto).WithMany(p => p.GyogyszerAdatoks)
                .HasForeignKey(d => d.GyartoId)
                .HasConstraintName("gyogyszer_adatok_ibfk_1");
        });

        modelBuilder.Entity<Orvosok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orvosok");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Beosztas).HasMaxLength(64);
            entity.Property(e => e.Nev).HasMaxLength(64);
        });

        modelBuilder.Entity<Paciensek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("paciensek");

            entity.HasIndex(e => e.Taj, "taj").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(255)
                .HasColumnName("nev");
            entity.Property(e => e.Taj)
                .HasMaxLength(11)
                .HasColumnName("taj");
        });

        modelBuilder.Entity<Receptek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("receptek");

            entity.HasIndex(e => e.GyogyszerId, "GyogyszerId");

            entity.HasIndex(e => e.OrvosId, "OrvosId");

            entity.HasIndex(e => e.PaciensId, "PaciensId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.GyogyszerId).HasColumnType("int(11)");
            entity.Property(e => e.OrvosId).HasColumnType("int(11)");
            entity.Property(e => e.PaciensId).HasColumnType("int(11)");

            entity.HasOne(d => d.Gyogyszer).WithMany(p => p.Recepteks)
                .HasForeignKey(d => d.GyogyszerId)
                .HasConstraintName("receptek_ibfk_2");

            entity.HasOne(d => d.Orvos).WithMany(p => p.Recepteks)
                .HasForeignKey(d => d.OrvosId)
                .HasConstraintName("receptek_ibfk_3");

            entity.HasOne(d => d.Paciens).WithMany(p => p.Recepteks)
                .HasForeignKey(d => d.PaciensId)
                .HasConstraintName("receptek_ibfk_4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.PermissionId, "Jog");

            entity.HasIndex(e => e.LoginNev, "LoginNev").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(64);
            entity.Property(e => e.Hash)
                .HasMaxLength(64)
                .HasColumnName("HASH");
            entity.Property(e => e.LoginNev).HasMaxLength(16);
            entity.Property(e => e.Name).HasMaxLength(64);
            entity.Property(e => e.PermissionId).HasColumnType("int(11)");
            entity.Property(e => e.ProfilePicturePath).HasMaxLength(64);
            entity.Property(e => e.Salt)
                .HasMaxLength(64)
                .HasColumnName("SALT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
