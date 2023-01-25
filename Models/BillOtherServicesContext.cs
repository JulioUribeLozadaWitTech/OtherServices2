using System;
using System.Collections.Generic;
//using LunesBorrar.Models;
using Microsoft.EntityFrameworkCore;
using OtherServices2.Borrar;
using OtherServices2.Models;
using OtherServices2.Models2;

namespace OtherServices2.Models;

public partial class BillOtherServicesContext : DbContext
{
    public BillOtherServicesContext()
    {
    }

    public BillOtherServicesContext(DbContextOptions<BillOtherServicesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GrupoServicio> GrupoServicios { get; set; }
    public virtual DbSet<Servicio> Servicios { get; set; }
    public virtual DbSet<Tercero> Terceros { get; set; }
    public virtual DbSet<TipoIdentTercero> TipoIdentTerceros { get; set; }
    public virtual DbSet<TipoServicio> TipoServicios { get; set; }
    public virtual DbSet<Factura> Facturas { get; set; }
    public virtual DbSet<FacturaDet> FacturaDets { get; set; }
    public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
    public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
    public virtual DbSet<Cupo> Cupos { get; set; } = null!;
    public virtual DbSet<VigenciaCupo> VigenciaCupos { get; set; } = null!;
    public virtual DbSet<PayRegister> PayRegisters { get; set; } = null!;
    //public virtual DbSet<Certificacione> Certificaciones { get; set; } = null!;
    public virtual DbSet<Certification> Certifications { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<GrupoServicio>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK_Grupos_de_Servicios");

            entity.ToTable("GrupoServicios", "FACT");

            entity.Property(e => e.IdGrupo)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).HasMaxLength(30);
            entity.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");

            entity.Property(e => e.thumbnails)
            .HasColumnType("varbinary").IsRequired(false);

            entity.Property(e => e.IdTipoServicio)
                .HasMaxLength(3)
                .IsUnicode(false);
            //
            entity.HasOne(d => d.IdTipoServicioNavigation)
                .WithMany(p => p.GrupoServicios)
                .HasForeignKey(d => d.IdTipoServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrupoServicios_TipoServicio");
            //
        });

        //modelBuilder.Entity<Servicio>(entity =>
        //{
        //    entity.HasKey(e => e.Codigo);

        //    entity.ToTable("Servicios", "FACT");

        //    entity.Property(e => e.Codigo)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Descripcion)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.FechaRegistro)
        //    .HasDefaultValueSql("(getdate())")
        //    .HasColumnType("datetime");
        //    entity.Property(e => e.IdGrupo)
        //        .HasMaxLength(3)
        //        .IsUnicode(false);
        //    entity.Property(e => e.IdTipoServicio)
        //        .HasMaxLength(3)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Valor)
        //        .HasColumnType("decimal(12, 0)")
        //        .HasColumnName("Valor");


        //entity.Property(e => e.ValorInscripcion)
        //    .HasMaxLength(10)
        //    .IsFixedLength()
        //    .HasColumnName("Valor Inscripcion");


        //    entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Servicios)
        //        .HasForeignKey(d => d.IdGrupo)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Servicios_Grupos_de_Servicios");

        //    entity.HasOne(d => d.IdTipoServicioNavigation).WithMany(p => p.Servicios)
        //        .HasForeignKey(d => d.IdTipoServicio)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Servicios_Tipo_Servicio");
        //});

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("PK_Servicios");

            entity.ToTable("Servicios", "FACT");

            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IdGrupo)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.IdTipoServicio)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.Valor).HasColumnType("decimal(12, 0)");

            entity.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicios_GrupoServicios");

            entity.HasOne(d => d.IdTipoServicioNavigation)
                .WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdTipoServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicios_TipoServicio");
        });

        modelBuilder.Entity<Tercero>(entity =>
        {
            entity.HasKey(e => e.DocIdentTercero);

            entity.ToTable("Tercero", "GEN");

            entity.Property(e => e.DocIdentTercero)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.BarrioDomicilio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CodMpioDomicilio)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CodOccupation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CodPaisDomicilio)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CorreoCorporativo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoPersonal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionDomicilio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DocUnicoTercero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Movil)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoAlterno)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoDomicilio)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TipoIdentTercero)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Vinculacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Zona)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('URBANA')");

            entity.HasOne(d => d.TipoIdentTerceroNavigation).WithMany(p => p.Terceros)
                .HasForeignKey(d => d.TipoIdentTercero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tercero_TipoIdentTercero");
        });

        modelBuilder.Entity<TipoIdentTercero>(entity =>
        {
            entity.HasKey(e => e.TipoIdentTercero1).HasName("PK_Tipo_Servicio");

            entity.ToTable("TipoIdentTercero", "GEN");

            entity.Property(e => e.TipoIdentTercero1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("TipoIdentTercero");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.IdTipoServicio).HasName("PK_Tipo_Servicio");

            entity.ToTable("TipoServicio", "FACT");

            entity.Property(e => e.IdTipoServicio)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdata())")
            .HasColumnType("datetime");
            entity.Property(e => e.TipoServicio1)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("TipoServicio");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.DocUnicoFact).HasName("PK_Factura_1");

            entity.ToTable("Factura", "FACT");

            entity.Property(e => e.DocUnicoFact)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodConvenio)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Concepto)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cufe)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CufeDateEmail).HasColumnType("datetime");
            entity.Property(e => e.CufeImage).HasColumnType("image");
            entity.Property(e => e.DatoResolNum)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DocIdentTercero)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.EstadoFact)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.FechaAnulacion).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.FechaVence).HasColumnType("date");
            entity.Property(e => e.Movil)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreConvenio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreTercero)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PrefijoFactura)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.TipoIdentTercero)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioAnulacion)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.VrDcto).HasColumnType("decimal(14, 2)");
            entity.Property(e => e.VrFactura).HasColumnType("decimal(14, 2)");
        });

        modelBuilder.Entity<FacturaDet>(entity =>
        {
            entity.HasKey(e => e.IdFacturaDet);

            entity.ToTable("FacturaDet", "FACT");

            entity.HasIndex(e => e.DocUnicoFact, "IX_FacturaDet");

            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DocUnicoFact)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.MedioPago)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.VrItem).HasColumnType("decimal(12, 0)");
            entity.HasOne(d => d.DocUnicoFactNavigation).WithMany(p => p.FacturaDets)
                .HasForeignKey(d => d.DocUnicoFact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturaDet_Factura");
        });

        //modelBuilder.Entity<Funcionario>(entity =>
        //{
        //    entity.HasKey(e => e.DocIdentTercero)
        //        .HasName("PK_Funcionarios");

        //    entity.ToTable("Funcionario", "FUN");

        //    entity.Property(e => e.DocIdentTercero)
        //        .HasMaxLength(17)
        //        .IsUnicode(false);

        //    entity.Property(e => e.BarrioDomicilio)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CodArl)
        //        .HasMaxLength(3)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CodFondoCes)
        //        .HasMaxLength(3)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CodFondoP)
        //        .HasMaxLength(3)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CodInstEduc)
        //        .HasMaxLength(3)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CodMpioDomicilio)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CodNivel)
        //        .HasMaxLength(3)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CodOccupation)
        //        .HasMaxLength(4)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CodPaisDomicilio)
        //        .HasMaxLength(5)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CodTipoVinc)
        //        .HasMaxLength(3)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CorreoCorporativo)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.CorreoPersonal)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.DireccionDomicilio)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);

        //    entity.Property(e => e.DocUnicoTercero)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Fax)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);

        //    entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

        //    entity.Property(e => e.Genero)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);

        //    entity.Property(e => e.MaritalStatus)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Movil)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Nombre)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);

        //    entity.Property(e => e.PostalCode)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);

        //    entity.Property(e => e.PrimerApellido)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.PrimerNombre)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.SegundoApellido)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.SegundoNombre)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.TelefonoAlterno)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);

        //    entity.Property(e => e.TelefonoDomicilio)
        //        .HasMaxLength(30)
        //        .IsUnicode(false);

        //    entity.Property(e => e.TipoIdentTercero)
        //        .HasMaxLength(3)
        //        .IsUnicode(false);

        //    entity.Property(e => e.UsuarioRegistro)
        //        .HasMaxLength(15)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Vinculacion)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Zona)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);
        //});

        //modelBuilder.Entity<Vehiculo>(entity =>
        //{
        //    entity.HasKey(e => e.IdVehiculo)
        //        .HasName("PK_Vehiculos");

        //    entity.ToTable("Vehiculo", "PARQ");

        //    entity.HasIndex(e => new { e.DocIdentTercero, e.Placa }, "IX_Vehiculo");

        //    entity.Property(e => e.IdVehiculo).ValueGeneratedNever();

        //    entity.Property(e => e.Color)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.DocIdentTercero)
        //        .HasMaxLength(17)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Linea)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Marca)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Placa)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Principal).HasDefaultValueSql("((1))");

        //    entity.Property(e => e.Tipo)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);

        //    entity.HasOne(d => d.DocIdentTerceroNavigation)
        //        .WithMany(p => p.Vehiculos)
        //        .HasForeignKey(d => d.DocIdentTercero)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Vehiculos_Funcionarios");
        //});

        //modelBuilder.Entity<Vehiculo>(entity =>
        //{
        //    entity.HasKey(e => e.IdVehiculo)
        //        .HasName("PK_Vehiculos");

        //    entity.ToTable("Vehiculo", "PARQ");

        //    entity.HasIndex(e => new { e.DocIdentTercero, e.Placa }, "IX_Vehiculo");

        //    entity.Property(e => e.Color)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.DocIdentTercero)
        //        .HasMaxLength(17)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Linea)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Marca)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Placa)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Principal).HasDefaultValueSql("((1))");

        //    entity.Property(e => e.Tipo)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);

        //    entity.HasOne(d => d.DocIdentTerceroNavigation)
        //        .WithMany(p => p.Vehiculos)
        //        .HasForeignKey(d => d.DocIdentTercero)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Vehiculos_Funcionarios");
        //});

        //modelBuilder.Entity<Vehiculo>(entity =>
        //{
        //    entity.HasKey(e => e.IdVehiculo)
        //        .HasName("PK_Vehiculos");

        //    entity.ToTable("Vehiculo", "PARQ");

        //    entity.HasIndex(e => new { e.DocIdentTercero, e.Placa }, "IX_Vehiculo");

        //    entity.Property(e => e.Color)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.DocIdentTercero)
        //        .HasMaxLength(17)
        //        .IsUnicode(false);

        //    entity.Property(e => e.FechaRegistro)
        //        .HasColumnType("datetime")
        //        .HasDefaultValueSql("(getdate())");

        //    entity.Property(e => e.Linea)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Marca)
        //        .HasMaxLength(20)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Placa)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Principal).HasDefaultValueSql("((1))");

        //    entity.Property(e => e.Tipo)
        //        .HasMaxLength(10)
        //        .IsUnicode(false);

        //    entity.Property(e => e.UsuarioRegistro)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasDefaultValueSql("(user_name())");

        //    entity.HasOne(d => d.DocIdentTerceroNavigation)
        //        .WithMany(p => p.Vehiculos)
        //        .HasForeignKey(d => d.DocIdentTercero)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Vehiculos_Funcionarios");
        //});

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => new { e.IdVehiculo })
                .HasName("PK_Vehiculos");

            entity.ToTable("Vehiculo", "PARQ");

            entity.HasIndex(e => new { e.DocIdentTercero, e.Placa }, "IX_Vehiculo");

            entity.Property(e => e.DocIdentTercero)
                .HasMaxLength(17)
                .IsUnicode(false);

            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IdVehiculo).ValueGeneratedOnAdd();

            entity.Property(e => e.Linea)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Marca)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Principal).HasDefaultValueSql("((1))");

            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(user_name())");

            entity.HasOne(d => d.DocIdentTerceroNavigation)
                .WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.DocIdentTercero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehiculos_Funcionarios");
        });


        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.DocIdentTercero)
                .HasName("PK_Funcionarios");

            entity.ToTable("Funcionario", "FUN");

            entity.Property(e => e.DocIdentTercero)
                .HasMaxLength(17)
                .IsUnicode(false);

            entity.Property(e => e.BarrioDomicilio)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.CodArl)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.CodFondoCes)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.CodFondoP)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.CodInstEduc)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.CodMpioDomicilio)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.CodNivel)
                .HasMaxLength(3)
                .IsUnicode(false);

            //entity.Property(e => e.CodOccupation)
            //    .HasMaxLength(4)
            //    .IsUnicode(false);

            entity.Property(e => e.CodPaisDomicilio)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.CodTipoVinc)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.CorreoCorporativo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CorreoPersonal)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DireccionDomicilio)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.DocUnicoTercero)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Movil)
                .HasMaxLength(15)
                .IsUnicode(false);

            //entity.Property(e => e.Nombre)
            //    .HasMaxLength(100)
            //    .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.TelefonoAlterno)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.TelefonoDomicilio)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.TipoIdentTercero)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Vinculacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Zona)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cupo>(entity =>
        {
            entity.HasKey(e => e.IdCupo)
                .HasName("PK_Cupos");

            entity.ToTable("Cupo", "PARQ");

            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DocIdentTercero)
                .HasMaxLength(17)
                .IsUnicode(false);

            //entity.Property(e => e.FechaDesde)
            //.HasColumnType("datetime");

            //entity.Property(e => e.FechaHasta)
            //.HasColumnType("datetime");

            entity.HasOne(d => d.DocIdentTerceroNavigation)
                .WithMany(p => p.Cupos)
                .HasForeignKey(d => d.DocIdentTercero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cupos_Funcionarios");
        });

        //modelBuilder.Entity<VigenciaCupo>(entity =>
        //{
        //    entity.HasKey(e => e.IdVigencia);

        //    entity.Property(e => e.IdCupo);

        //    entity.ToTable("VigenciaCupo", "PARQ");

        //    entity.Property(e => e.DocIdentTercero)
        //        .HasMaxLength(17)
        //        .IsUnicode(false);

        //    entity.Property(e => e.FechaDesde).HasColumnType("date");

        //    entity.Property(e => e.FechaHasta).HasColumnType("date");

        //    entity.Property(e => e.Jornada)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.TipoVehiculo)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Placa)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.HasOne(d => d.DocIdentTerceroNavigation)
        //        .WithMany(p => p.VigenciaCupos)
        //        .HasForeignKey(d => d.DocIdentTercero)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_VigenciaParqueadero_Funcionarios");
        //});

        modelBuilder.Entity<VigenciaCupo>(entity =>
        {
            entity.HasKey(e => e.IdVigencia);

            entity.ToTable("VigenciaCupo", "PARQ");

            entity.Property(e => e.DocIdentTercero)
                .HasMaxLength(17)
                .IsUnicode(false);

            entity.Property(e => e.FechaDesde).HasColumnType("date");

            entity.Property(e => e.FechaHasta).HasColumnType("date");

            //entity.Property(e => e.FechaRegistro)
            //    .HasColumnType("datetime")
            //    .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Jornada)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Placa)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TipoVehiculo)
                .HasMaxLength(50)
                .IsUnicode(false);

            //entity.Property(e => e.UsuarioRegistro)
            //    .HasMaxLength(50)
            //    .IsUnicode(false)
            //    .HasDefaultValueSql("(user_name())");

            entity.HasOne(d => d.DocIdentTerceroNavigation)
                .WithMany(p => p.VigenciaCupos)
                .HasForeignKey(d => d.DocIdentTercero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VigenciaCupo_Funcionario");

            entity.HasOne(d => d.IdCupoNavigation)
                .WithMany(p => p.VigenciaCupos)
                .HasForeignKey(d => d.IdCupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VigenciaCupo_Cupo");

            entity.HasOne(d => d.IdPayRegisterNavigation)
                .WithMany(p => p.VigenciaCupos)
                .HasForeignKey(d => d.IdPayRegister)
                .HasConstraintName("FK_VigenciaParqueadero_Funcionarios");

            entity.HasOne(d => d.IdServiceNavigation)
                .WithMany(p => p.VigenciaCupos)
                .HasForeignKey(d => d.IdService)
                .HasConstraintName("FK_VigenciaCupo_Servicios");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu)
                .HasName("PK_IDMENU");

            entity.ToTable("MENU", "MENU");

            entity.Property(e => e.IdMenu)
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd()
                .HasColumnName("IdMenu");

            entity.Property(e => e.Accion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Accion");

            entity.Property(e => e.Controlador)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Controlador");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Descripcion");

            entity.Property(e => e.Esactivo)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("Esactivo")
                .HasDefaultValueSql("1");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("FechaRegistro")
                .HasDefaultValueSql("sysdate");

            entity.Property(e => e.Icono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Icono");

            entity.Property(e => e.IdMenuPadre)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("IdMenuPadre");

            entity.HasOne(d => d.IdMenuPadreNavigation)
                .WithMany(p => p.InverseIdMenuPadreNavigation)
                .HasForeignKey(d => d.IdMenuPadre)
                .HasConstraintName("FK_MENU_MENU");
        });

        modelBuilder.Entity<PayRegister>(entity =>
        {
            entity.HasKey(e => e.IdPayRegister);

            entity.ToTable("PayRegister", "PAYLINK");

            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

            entity.Property(e => e.PayDate).HasColumnType("datetime");

            entity.Property(e => e.PayNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        //modelBuilder.Entity<Certificacione>(entity =>
        //{
        //    entity.HasKey(e => e.IdCertification)
        //        .HasName("PK_CERT.CERTIFICACIONES");

        //    entity.ToTable("CERTIFICACIONES", "CERT");

        //    entity.Property(e => e.IdCertification).ValueGeneratedNever();

        //    entity.Property(e => e.Address)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Ciudad)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.ContractNumber)
        //        .HasMaxLength(150)
        //        .IsUnicode(false);

        //    entity.Property(e => e.DateSuscripcion).HasColumnType("date");

        //    entity.Property(e => e.DocIdentContrator)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.DocIdentSupervisor)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Email)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.ExtensionTerm).HasColumnType("date");

        //    entity.Property(e => e.FinalTerm).HasColumnType("date");

        //    entity.Property(e => e.InitialTerm).HasColumnType("date");

        //    entity.Property(e => e.IssueDate).HasColumnType("date");

        //    entity.Property(e => e.MobilePhone)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.ModificatorioReduccionNo1).HasColumnType("numeric(18, 0)");

        //    entity.Property(e => e.NoContract)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.Object)
        //        .HasMaxLength(500)
        //        .IsUnicode(false);

        //    entity.Property(e => e.StateContract)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.TypeContract)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);

        //    entity.Property(e => e.VrAdicionNo1).HasColumnType("numeric(18, 0)");

        //    entity.Property(e => e.VrAdicionNo2).HasColumnType("numeric(18, 0)");

        //    entity.Property(e => e.VrAdicionNo3).HasColumnType("numeric(18, 0)");

        //    entity.Property(e => e.VrInicial).HasColumnType("numeric(18, 0)");

        //    entity.Property(e => e.VrTotalContrato).HasColumnType("numeric(18, 0)");
        //});

        // BORRAR MODELO

        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.IdCertification)
                .HasName("PK_CERT.CERTIFICACIONES");

            entity.ToTable("Certification", "CERT");

            entity.Property(e => e.IdCertification).ValueGeneratedNever();

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ContractNumber)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.DateSuscripcion).HasColumnType("date");

            entity.Property(e => e.DocIdentContrator)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DocIdentSupervisor)
            .HasMaxLength(50)
            .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ExtensionTerm).HasColumnType("date");

            entity.Property(e => e.FinalTerm).HasColumnType("date");

            entity.Property(e => e.InitialTerm).HasColumnType("date");

            entity.Property(e => e.InitialTerm).HasColumnType("date");

            entity.Property(e => e.IssueDate).HasColumnType("date");

            entity.Property(e => e.MobilePhone)
            .HasMaxLength(50)
            .IsUnicode(false);

            entity.Property(e => e.ModificatorioReduccionNo1).HasColumnType("numeric(18, 0)");

            entity.Property(e => e.NoContract)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Object)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.StateContract)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TypeContract)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ValueAaddictionNo2).HasColumnType("numeric(18, 0)");

            entity.Property(e => e.ValueAddictionNo1).HasColumnType("numeric(18, 0)");

            entity.Property(e => e.ValueAddictionNo3).HasColumnType("numeric(18, 0)");

            entity.Property(e => e.ValueFinalContract).HasColumnType("numeric(18, 0)");

            entity.Property(e => e.ValueInicial).HasColumnType("numeric(18, 0)");

        });
            
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
