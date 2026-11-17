using Microsoft.EntityFrameworkCore;
using Web_IB.Entities;

namespace Web_IB.Data
{
    public class MyDbContextPortfolio : DbContext
    {
        public MyDbContextPortfolio(DbContextOptions<MyDbContextPortfolio> options) : base(options) { }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Expediteur)
                .WithMany()
                .HasForeignKey(m => m.ExpediteurId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Destinataire)
                .WithMany()
                .HasForeignKey(m => m.DestinataireId)
                .OnDelete(DeleteBehavior.Restrict); 
        }


    }
}
