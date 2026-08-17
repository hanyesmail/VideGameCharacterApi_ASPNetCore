using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameCharacterApi.Data.Models;

namespace VideoGameCharacterApi.Data.Configurations;

public class StudentEntityTypeConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // builder.HasOne(s => s.StudentImage)
        //     .WithOne(s => s.Student)
        //     .HasForeignKey<Student>(s => s.ImageId);

        // builder.HasMany(s => s.StudentImages)
        //     .WithOne();
    }
}