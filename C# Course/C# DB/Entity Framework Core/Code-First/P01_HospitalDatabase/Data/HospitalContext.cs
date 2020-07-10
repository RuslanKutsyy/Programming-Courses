using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            :base(options)
        {
        }


        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<PatientMedicament> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);
                
                entity.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

                entity.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired();

                entity.Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode(true)
                .IsRequired(true);

                entity.Property(p => p.Email)
                .HasColumnType("VARCHAR(80)")
                .HasMaxLength(80)
                .IsRequired(true)
                .IsUnicode(false);

                entity.Property(p => p.HasInsurance).IsRequired();

                entity.HasMany(p => p.Prescriptions)
                .WithOne(pm => pm.Patient);

                entity.HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient);

                entity.HasMany(p => p.Visitations)
                .WithOne(v => v.Patient);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(v => v.VisitationId);

                entity.Property(v => v.Date).IsRequired();

                entity.Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode(true)
                .IsRequired(true);

                entity.HasOne(v => v.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(v => v.PatientId);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(d => d.DiagnoseId);

                entity.Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

                entity.Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode(true)
                .IsRequired(true);

                entity.HasOne(d => d.Patient)
                .WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.MedicamentId);

                entity.Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(false);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.MedicamentId, pm.PatientId });

                entity.HasOne(pm => pm.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);

                entity.HasOne(pm => pm.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);
            });
        }
    }
}
