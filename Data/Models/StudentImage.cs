using System.ComponentModel.DataAnnotations;

namespace VideoGameCharacterApi.Data.Models;

public class StudentImage
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string? Image { get; set; }
    
    public int? StudentId { get; set; }
    
    public Student? student { get; set; }
}