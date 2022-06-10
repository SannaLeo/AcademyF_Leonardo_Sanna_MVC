using AcademyF_Leonardo_Sanna_MVC.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyF_Leonardo_Sanna_MVC.RepositoryEF.Configurations
{
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Descrizione).IsRequired();
            builder.Property(x => x.Tipologia).IsRequired();
            builder.Property(x => x.Prezzo).IsRequired();

            builder.HasOne(x => x.Menu).WithMany(m => m.Piatti).HasForeignKey(x => x.MenuId);
        }
    }
}