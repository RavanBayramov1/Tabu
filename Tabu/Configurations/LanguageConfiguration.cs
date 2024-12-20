    using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabu.Entities;

namespace Tabu.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder
            .HasKey(x => x.Code);
        builder
            .Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(2);
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);
        builder.HasIndex(x => x.Name)
            .IsUnique();
        builder
            .Property(x => x.Icon)
            .IsRequired()
            .HasMaxLength(128);
        builder.HasData(new Language
        {
            Code = "Az",
            Icon = "https://upload.wikimedia.org/wikipedia/commons/3/3d/AZ-Azerbaijan-Flag-icon.png",
            Name = "Azerbaijan"
        },
        new Language 
        {
            Code = "En",
            Icon = "https://cdn-icons-png.freepik.com/256/6737/6737832.png?semt=ais_hybrid",
            Name = "English"
        });

    }
}
