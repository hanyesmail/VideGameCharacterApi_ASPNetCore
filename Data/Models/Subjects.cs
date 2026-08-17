using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VideoGameCharacterApi.Data.Models;

public class Subjects
{
    [Key]
    public int SubjectId { get; set; }
    
    [MaxLength(100)]
    public String? SubjectName { get; set; }

    // ICollection<T>  --> To define many to many relationship
    // public ICollection<Student>? Students { get; set; }
}