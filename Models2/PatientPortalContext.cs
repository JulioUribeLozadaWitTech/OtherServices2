using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OtherServices2.Models2;

public partial class PatientPortalContext : DbContext
{
    public PatientPortalContext()
    {
    }

    public PatientPortalContext(DbContextOptions<PatientPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Encuestum> Encuesta { get; set; }

    public virtual DbSet<GrupoServ> GrupoServs { get; set; }

    public virtual DbSet<ServicePortal> ServicePortals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=52.167.159.64; database=PatientPortal; user id=developer4; pwd=Developer4.; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.Terminos)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Encuestum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ComoEsperaria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CualCanalPreferiria)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GrupoServ>(entity =>
        {
            entity.ToTable("GrupoServ");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Thumbnails).HasColumnName("thumbnails");
        });

        modelBuilder.Entity<ServicePortal>(entity =>
        {
            entity.HasKey(e => e.IdServicePortal);

            entity.ToTable("ServicePortal", "GEN");

            entity.Property(e => e.Href)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("href");
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ServiceName)
                .HasMaxLength(200)
                .IsUnicode(false);
            //entity.Property(e => e.ServiceThumbnail).IsUnicode(false);
            entity.Property(e => e.TypeCostThumb).IsUnicode(false);
            entity.Property(e => e.TypeProcedure)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeProcedureThumb).IsUnicode(false);
            entity.Property(e => e.TypeTimeThumb).IsUnicode(false);
            entity.Property(e => e.WhenToDo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WhenToDoThumb).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
