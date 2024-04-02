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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Addresses { get;set;}
        public DbSet<Models.Concept> Concepts { get; set; }
        public DbSet <ConceptSet> ConceptSets { get; set; }
        public DbSet<NamePart> NameParts { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientLanguage> PatientLanguages { get; set; }
        public DbSet<PatientTelecom> PatientTelecoms { get; set; }

    }
}
