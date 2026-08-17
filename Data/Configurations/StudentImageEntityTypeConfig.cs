using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameCharacterApi.Data.Models;

namespace VideoGameCharacterApi.Data.Configurations;

public class StudentImageEntityTypeConfig : IEntityTypeConfiguration<StudentImage>
{
    public void Configure(EntityTypeBuilder<StudentImage> builder)
    {
        builder
            .HasOne(si => si.student)
            .WithMany(s => s.StudentImages)
            .HasForeignKey(si => si.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}