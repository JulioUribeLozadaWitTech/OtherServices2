using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OtherServices2.Models3;

public partial class PlantaContext : DbContext
{
    public PlantaContext()
    {
    }

    public PlantaContext(DbContextOptions<PlantaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grado> Grados { get; set; }

    public virtual DbSet<Grado1> Grados1 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=52.167.159.64; database=PLANTA; user id=developer4; pwd=Developer4.; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grado>(entity =>
        {
            entity.HasKey(e => e.IdGrado).HasName("PK_Grado_1");

            entity.ToTable("Grado", "COM");

            entity.Property(e => e.FuerzaMilitar)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Grado1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Grado");
            entity.Property(e => e.TipoPlanta)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grado1>(entity =>
        {
            entity.HasKey(e => e.CodGrado);

            entity.ToTable("Grado", "PLC");

            entity.Property(e => e.CodGrado)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
