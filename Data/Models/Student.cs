using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VideoGameCharacterApi.Data.Models;

// To add index on specific column with unique value
[Index(nameof(Name), IsUnique = true)]
public class Student
{
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(50)"), MaxLength(50)]
    public string? Name { get; set; }

    public List<StudentImage>? StudentImages { get; set; }

    public int Sequence { get; set; }

    //ICollection<T>  --> To define many to many relationship
    public ICollection<Subjects>? Subject { get; set; }
}