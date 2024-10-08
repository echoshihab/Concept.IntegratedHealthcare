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
            // Patient & Individual
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Individual);

            modelBuilder.Entity<Practitioner>()
                .HasOne(p => p.Individual);

            // Patient & Gender
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.GenderConcept);

            // Patient and Patient Practitioner
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.PatientPractitioners)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);
               
            // Individual and Identifier
            modelBuilder.Entity<Individual>()
                .HasMany(i => i.Identifiers)
                .WithOne(id => id.Individual)
                .HasForeignKey(id => id.IndividualId);

            // Individual & name
            modelBuilder.Entity<Individual>()
                .HasMany(i => i.NameParts)
                .WithOne(n => n.Individual)
                .HasForeignKey(n => n.IndividualId);

            // Individual & Address
            modelBuilder.Entity<Individual>()
                .HasMany(i => i.Addresses)
                .WithOne(i => i.Individual)
                .HasForeignKey(n => n.IndividualId);

            // Individual & Individual Type
            modelBuilder.Entity<Individual>()
                .HasOne(i => i.IndividualTypeConcept);

            // Patient & Language
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Languages)
                .WithOne(l => l.Patient)
                .HasForeignKey(l => l.PatientId);        
                
            // Patient and telecommunication
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Telecoms)
                .WithOne(t => t.Patient)            
                 .HasForeignKey(l => l.PatientId);               

            // Practitioner and telecommunication
            modelBuilder.Entity<Practitioner>()
                .HasMany(p => p.Telecoms)
                .WithOne(t => t.Practitioner)
                 .HasForeignKey(t => t.PractitionerId);

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

            // Procedure Detail
            modelBuilder.Entity<ProcedureDetail>()
                .Property(p => p.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Modality>()
                .Property(p => p.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(s => s.Requester)
                    .WithMany()
                .HasForeignKey(s => s.RequesterId)
                .HasPrincipalKey(p => p.PractitionerReferenceId);               
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Models.Concept> Concepts { get; set; }
        public DbSet<ConceptSet> ConceptSets { get; set; }
        public DbSet<NamePart> NameParts { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<PatientLanguage> PatientLanguages { get; set; }
        public DbSet<PatientTelecom> PatientTelecoms { get; set; }
        public DbSet<PractitionerTelecom> PractitionerTelecoms { get; set; }
        public DbSet<Individual> Individuals { get; set; }       
        public DbSet<PatientPractitioner> PatientPractitioners { get; set; }
        public DbSet<ProcedureDetail> ProcedureDetails { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Modality> Modalities { get; set; }
    }
}
