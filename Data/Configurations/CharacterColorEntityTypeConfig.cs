using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Data.Configurations;

public class CharacterColorEntityTypeConfig : IEntityTypeConfiguration<CharacterColor>
{
    public void Configure(EntityTypeBuilder<CharacterColor> builder)
    {
        builder.Property(p => p.ColorName).IsRequired();
    }
}