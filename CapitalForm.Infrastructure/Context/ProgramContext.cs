using CapitalForm.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapitalForm.Infrastructure.Context
{
    public class ProgramContext : DbContext
    {
        public ProgramContext() { }

        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("program");

            modelBuilder.Entity<QuestionType>()
                .ToContainer(nameof(QuestionType))
                .HasPartitionKey(c => c.Id)
                .HasNoDiscriminator();

            modelBuilder.Entity<ProgramApplication>()
                .ToContainer(nameof(ProgramApplication))
                .HasPartitionKey(c => c.Id)
                .HasNoDiscriminator();
        }

        public DbSet<ProgramApplication> Applications { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
    }
}
