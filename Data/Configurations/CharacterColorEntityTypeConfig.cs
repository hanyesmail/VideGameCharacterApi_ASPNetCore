using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameCharacterApi.Data.Models;

namespace VideoGameCharacterApi.Data.Configurations;

public class CharacterColorEntityTypeConfig : IEntityTypeConfiguration<CharacterColor>
{
    public void Configure(EntityTypeBuilder<CharacterColor> builder)
    {
        builder.Property(p => p.ColorName).IsRequired();

        // To execlude Entity from any migration changes 
        // builder.ToTable("TableName", t => t.ExcludeFromMigrations());
        // ==============================================
        
        // We can add table under different schema by this way
        // builder.ToTable("TableName", schema: "DifferentSchemaName");
        // ==============================================
        
        // To change type of column Or set Max Length Or adding comment Or set primary key Or set composite key (more than one key)
        // builder.Property(x => x.ColorName).HasColumnType("varchar(100)");
        // builder.Property(x => x.ColorName).HasMaxLength(20);
        // builder.Property(x => x.ColorName).HasComment("add your comment");
        // builder.HasKey(x => x.Id);
        // builder.HasKey(x => x.Id).HasName("To Change PK name");
        // Composite Key => builder.HasKey(x => new {x.Id, x.ColorName});
        // ==============================================
        
        // To set default value for any column
        // builder.Property(x => x.ColorName).HasDefaultValue("Default Value");
        // ==============================================
        
        // To give default value to the identifier of type not integer ex. Byte
        // builder.Property(x => x.Id).ValueGeneratedOnAdd();
        // ==============================================
    }
}