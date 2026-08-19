using System.ComponentModel.DataAnnotations;

namespace VideoGameCharacterApi.Data.Models;

public class Author
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string? Name { get; set; }
    public int? NationalityId { get; set; }
}