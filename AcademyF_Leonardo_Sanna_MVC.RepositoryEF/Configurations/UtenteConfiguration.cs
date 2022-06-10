using AcademyF_Leonardo_Sanna_MVC.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyF_Leonardo_Sanna_MVC.RepositoryEF.Configurations
{
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utente");
            builder.HasKey(u => u.Id).HasName("PK_Utente");
            builder.Property(u=>u.Username).IsRequired();
            builder.Property(u=>u.Password).IsRequired();

        }
    }
}