using Microsoft.Build.Framework;

namespace VideoGameCharacterApi.Models;

public class CharacterType
{
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
}