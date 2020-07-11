using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

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


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);

                entity.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

                entity.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode();

                entity.Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();

                entity.Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

                //entity.Property(p => p.HasInsurance)
                //.IsRequired();

                //entity.HasMany(p => p.Prescriptions)
                //.WithOne(pr => pr.Patient)
                //.HasForeignKey(p => p.PatientId);

                //entity.HasMany(p => p.Diagnoses)
                //.WithOne(d => d.Patient)
                //.HasForeignKey(d => d.DiagnoseId);

                //entity.HasMany(p => p.Visitations)
                //.WithOne(v => v.Patient)
                //.HasForeignKey(v => v.VisitationId);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(v => v.VisitationId);

                entity.Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode();

                entity.HasOne(v => v.Patient)
                .WithMany(p => p.Visitations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(v => v.PatientId);

                entity.HasOne(v => v.Doctor)
                .WithMany(d => d.Visitations)
                .HasForeignKey(v => v.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(d => d.DiagnoseId);

                entity.Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode();

                entity.Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode();

                entity.HasOne(d => d.Patient)
                .WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.MedicamentId);

                entity.Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode();

                //entity.HasMany(m => m.Prescriptions)
                //.WithOne(m => m.Medicament)
                //.HasForeignKey(m => m.MedicamentId);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                entity.HasOne(pm => pm.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pm => pm.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pm => pm.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.DoctorId);

                entity.Property(d => d.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

                entity.Property(d => d.Specialty)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();
            });
        }
    }
}
