using System.ComponentModel.DataAnnotations;

namespace VideoGameCharacterApi.Data.Models;

// To ignore adding Entity to the database
// 2- Adding Annotation proparty [NotMapped] to the navigation proparty
// ==============================================
//[NotMapped]
public class CharacterType
{
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public string? Name { get; set; }
}