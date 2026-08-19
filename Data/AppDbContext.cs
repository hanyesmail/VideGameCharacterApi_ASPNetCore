using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data.Configurations;
using VideoGameCharacterApi.Data.Models;


namespace VideoGameCharacterApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // To reference to Entity Type Configurations files 
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(CharacterColorEntityTypeConfig).Assembly);
        new CharacterColorEntityTypeConfig().Configure(modelBuilder.Entity<CharacterColor>());
        new CharacterEntityTypeConfig().Configure(modelBuilder.Entity<Character>());
        new StudentEntityTypeConfig().Configure(modelBuilder.Entity<Student>());
        new StudentImageEntityTypeConfig().Configure(modelBuilder.Entity<StudentImage>());
        // ==============================================
        
        // To add new database table without adding new DbSet
        // 1- Fluent API -> modelBuilder.Entity<CharacterTypes>();
        // 2- add it as a navigation property in any existing entity 
        //    we can ignore adding it to the database by adding
        //    annotation prparty [NotMapped] to this navigation proparty
        // 3- add DbSet for it in AppDbContext
        // 4- Fluent API -> and you can add it with different name from the Entity model
        //    modelBuilder.Entity<EntityName>().ToTable("DifferentName");
        // ==============================================
        
        // To ignore adding Entity to the database
        // 1- Fluent API -> modelBuilder.Ignore<EntityModelName>();
        // 2- Adding Annotation proparty [NotMapped] to the navigation proparty
        // ==============================================
        
        // To set another schema as a default schema
        // modelBuilder.HasDefaultSchema("SchemaName");
        // ==============================================

        // Create Shared Sequence Number Over All DB Entities
        //modelBuilder.HasSequence<int>("SharedSequenceNumber");

        //------------- DATA SEEDING ------------------
        modelBuilder.Entity<Subjects>().HasData(new Subjects
        {
            SubjectId = 1,
            SubjectName = "Science"
        });

        modelBuilder.Entity<Subjects>().HasData(new Subjects
        {
            SubjectId = 2,
            SubjectName = "English"
        });
        
        modelBuilder.Entity<Subjects>().HasData(new Subjects
        {
            SubjectId = 3,
            SubjectName = "Arabic"
        });
        //================================================
    }

    public DbSet<Character> Characters => Set<Character>();
    public DbSet<CharacterType> CharacterTypes => Set<CharacterType>();
    public DbSet<CharacterColor> CharacterColors => Set<CharacterColor>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<StudentImage>  StudentImages => Set<StudentImage>();
    public DbSet<Subjects>  Subjects => Set<Subjects>();
    
    public DbSet<Book>  Books => Set<Book>();
    public DbSet<Author>  Authors => Set<Author>();
    public DbSet<Nationality>  Nationalities => Set<Nationality>();
}