using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGameCharacterApi.Data.Models;

public class Student
{
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(50)"), MaxLength(50)]
    public string? Name { get; set; }
}