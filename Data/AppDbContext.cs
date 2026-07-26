using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data.Configurations;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(CharacterColorEntityTypeConfig).Assembly);
        new CharacterColorEntityTypeConfig().Configure(modelBuilder.Entity<CharacterColor>());
    }

    public DbSet<Character> Characters => Set<Character>();
    
    public DbSet<CharacterType> CharacterTypes => Set<CharacterType>();
    
    public DbSet<CharacterColor> CharacterColors => Set<CharacterColor>();
}