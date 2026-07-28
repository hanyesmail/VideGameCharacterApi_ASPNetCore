namespace VideoGameCharacterApi.Data.Dtos;

public class CharacterDto
{
    public string Name { get; set; } = string.Empty;

    public string Game { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public string? TypeName { get; set; }

    public string? Color { get; set; }
}