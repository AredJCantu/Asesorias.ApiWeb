using System;
using System.Collections.Generic;
using AsesoriasAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace AsesoriasAPI.Data;

public partial class AsesoriasContext : DbContext
{
    public AsesoriasContext()
    {
    }

    public AsesoriasContext(DbContextOptions<AsesoriasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumno { get; set; }

    public virtual DbSet<Asesoria> Asesoria { get; set; }

    public virtual DbSet<Inscripcion> Inscripcion { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("alumno");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(60)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Matricula)
                .HasMaxLength(12)
                .HasColumnName("matricula");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Asesoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("asesoria");

            entity.HasIndex(e => e.IdTutor, "fkAlumnoAsesoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cupo).HasColumnName("cupo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdTutor).HasColumnName("id_tutor");
            entity.Property(e => e.Lugar)
                .HasMaxLength(150)
                .HasColumnName("lugar");
            entity.Property(e => e.Materia)
                .HasMaxLength(80)
                .HasColumnName("materia");

            entity.HasOne(d => d.IdTutorNavigation).WithMany(p => p.Asesoria)
                .HasForeignKey(d => d.IdTutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkAlumnoAsesoria");
        });

        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inscripcion");

            entity.HasIndex(e => e.IdAlumno, "FkInscripcionAlumno");

            entity.HasIndex(e => e.IdAsesoria, "FkInscripcionAsesoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            entity.Property(e => e.IdAsesoria).HasColumnName("id_asesoria");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.Inscripcion)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkInscripcionAlumno");

            entity.HasOne(d => d.IdAsesoriaNavigation).WithMany(p => p.Inscripcion)
                .HasForeignKey(d => d.IdAsesoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkInscripcionAsesoria");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
