using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MecanicoApi.Models
{
    public partial class mecanicoApiContext : DbContext
    {
        public mecanicoApiContext()
        {
        }

        public mecanicoApiContext(DbContextOptions<mecanicoApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Mecanico> Mecanicos { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Zona> Zonas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=laionsito; Password=1234567; Server=localhost; Database=mecanicoApi; Integrated Security=true; Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Argentina.1252");

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.EspecialidadId)
                    .HasName("especialidades_pkey");

                entity.ToTable("especialidades");

                entity.Property(e => e.EspecialidadId).HasColumnName("especialidad_id");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(40)
                    .HasColumnName("especialidad");
            });

            modelBuilder.Entity<Mecanico>(entity =>
            {
                entity.ToTable("mecanicos");

                entity.Property(e => e.MecanicoId).HasColumnName("mecanico_id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.EspecialidadId).HasColumnName("especialidad_id");

                entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.SexoId).HasColumnName("sexo_id");

                entity.Property(e => e.Soltero).HasColumnName("soltero");

                entity.Property(e => e.ZonaId).HasColumnName("zona_id");

                entity.HasOne(d => d.Especialidad)
                    .WithMany(p => p.Mecanicos)
                    .HasForeignKey(d => d.EspecialidadId)
                    .HasConstraintName("mecanicos_especialidad_id_fkey");

                entity.HasOne(d => d.Sexo)
                    .WithMany(p => p.Mecanicos)
                    .HasForeignKey(d => d.SexoId)
                    .HasConstraintName("mecanicos_sexo_id_fkey");

                entity.HasOne(d => d.Zona)
                    .WithMany(p => p.Mecanicos)
                    .HasForeignKey(d => d.ZonaId)
                    .HasConstraintName("mecanicos_zona_id_fkey");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.ToTable("sexos");

                entity.Property(e => e.SexoId).HasColumnName("sexo_id");

                entity.Property(e => e.Sexo1)
                    .HasMaxLength(20)
                    .HasColumnName("sexo");
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.ToTable("zonas");

                entity.Property(e => e.ZonaId).HasColumnName("zona_id");

                entity.Property(e => e.Zona1)
                    .HasMaxLength(40)
                    .HasColumnName("zona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
