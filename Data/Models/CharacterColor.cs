using System.ComponentModel.DataAnnotations;

namespace VideoGameCharacterApi.Data.Models;

public class CharacterColor
{
    // To give default value to the identifier of type not integer ex. Byte
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    // ==============================================
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string? ColorName { get; set; } 
}