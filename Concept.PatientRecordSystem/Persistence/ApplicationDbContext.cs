using Concept.PatientRecordSystem.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Concept.PatientRecordSystem.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Patient and address
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Addresses)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId);

            // Patient and name
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.NameParts)
                .WithOne(n => n.Patient)
                .HasForeignKey(n => n.PatientId);

            // Patient and language
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Languages)
                .WithMany(l => l.Patients)
                .UsingEntity<PatientLanguage>();

            // Patient and telecommunication
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Telecoms)
                .WithOne(t => t.Patient);

            // Patient and Identifier
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Identifiers)
                .WithOne(i => i.Patient);

            // Concept and concept set
            modelBuilder.Entity<Models.Concept>()
                .HasMany(p => p.ConceptSets)
                .WithMany(p => p.Concepts)
                .UsingEntity<ConceptConceptSet>();

            // Address and address use concept
            modelBuilder.Entity<Address>()
                .HasOne(a => a.AddressUseConcept);

            // Patient language and language concept
            modelBuilder.Entity<PatientLanguage>()
                .HasOne(l => l.LanguageConcept);



                
                

             
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Models.Concept> Concepts { get; set; }
        public DbSet<ConceptSet> ConceptSets { get; set; }
        public DbSet<NamePart> NameParts { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientLanguage> PatientLanguages { get; set; }
        public DbSet<PatientTelecom> PatientTelecoms { get; set; }
    }
}
