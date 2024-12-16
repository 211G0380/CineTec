using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace S7PWU5ProyectoTrailersDePeliculas.Models.Entities;

public partial class PeliculasBdContext : DbContext
{
    public PeliculasBdContext()
    {
    }

    public PeliculasBdContext(DbContextOptions<PeliculasBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clasificacion> Clasificacion { get; set; }

    public virtual DbSet<Generos> Generos { get; set; }

    public virtual DbSet<Peliculas> Peliculas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=PeliculasBD;port=3306;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.18-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Clasificacion>(entity =>
        {
            entity.HasKey(e => e.IdClasificacion).HasName("PRIMARY");

            entity.ToTable("clasificacion");

            entity.HasIndex(e => e.ClasificacionDePelicula, "ClasificacionDePelicula").IsUnique();

            entity.Property(e => e.IdClasificacion)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Clasificacion");
            entity.Property(e => e.ClasificacionDePelicula).HasMaxLength(50);
        });

        modelBuilder.Entity<Generos>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PRIMARY");

            entity.ToTable("generos");

            entity.HasIndex(e => e.NombreGenero, "Nombre_Genero").IsUnique();

            entity.Property(e => e.IdGenero)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Genero");
            entity.Property(e => e.NombreGenero)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Genero");
        });

        modelBuilder.Entity<Peliculas>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PRIMARY");

            entity.ToTable("peliculas");

            entity.HasIndex(e => e.IdClasificacion, "ID_Clasificacion");

            entity.HasIndex(e => e.IdGenero, "ID_Genero");

            entity.Property(e => e.IdPelicula)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Pelicula");
            entity.Property(e => e.AnioSalida)
                .HasColumnType("year(4)")
                .HasColumnName("Anio_Salida");
            entity.Property(e => e.Calificacion).HasPrecision(3, 1);
            entity.Property(e => e.Duracion).HasMaxLength(5);
            entity.Property(e => e.IdClasificacion)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Clasificacion");
            entity.Property(e => e.IdGenero)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Genero");
            entity.Property(e => e.LinkTrailer).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Resumen).HasColumnType("text");

            entity.HasOne(d => d.IdClasificacionNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.IdClasificacion)
                .HasConstraintName("peliculas_ibfk_2");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("peliculas_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
