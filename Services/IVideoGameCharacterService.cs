using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;
namespace VideoGameCharacterApi.Services;

public interface IVideoGameCharacterService
{
    Task<List<CharacterDto>> GetAllCharactersAsinc();
    Task<CharacterDto?> GetCharacterByIdAsinc(int characterId);
    Task<CharacterDto> CreateCharacterAsinc(CharacterDto character);
    Task<bool> UpdateCharacterAsinc(int characterId, CharacterDto character);
    Task<bool> DeleteCharacterAsinc(int characterId);
}