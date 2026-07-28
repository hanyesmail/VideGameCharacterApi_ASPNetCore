using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameCharacterApi.Data.Models;

namespace VideoGameCharacterApi.Data.Configurations;

public class CharacterEntityTypeConfig : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        // To set default value from SQL Statement (ex. Builtin Func)
        // builder.Property(x => x.CreationDate).HasDefaultValueSql("GETDATE()");
        // ==============================================
        
        // To set computed value from SQL Statement
        // builder.Property(x => x.Role).HasComputedColumnSql("[Game] + ',' + [Name]");
        // ==============================================
    }
}