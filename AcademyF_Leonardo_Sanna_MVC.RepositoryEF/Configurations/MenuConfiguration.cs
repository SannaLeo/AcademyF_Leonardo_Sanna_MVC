using AcademyF_Leonardo_Sanna_MVC.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyF_Leonardo_Sanna_MVC.RepositoryEF.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.id).HasName("PK_Menu");
            builder.Property(m => m.Nome).IsRequired();

            builder.HasMany(m=>m.Piatti).WithOne(p=>p.Menu).HasForeignKey(p=>p.MenuId);
        }
    }
}