using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Services;

public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
{

    public async Task<List<CharacterDto>> GetAllCharactersAsinc()
    {
        var characters = await context.Characters.Select(c => new CharacterDto
        {
            Name = c.Name,
            Game = c.Game,
            Role = c.Role,
        }).ToListAsync();
        return characters;
    } 

    public async Task<CharacterDto?> GetCharacterByIdAsinc(int characterId)
    {
        var result = await context.Characters.Where(c =>  c.Id == characterId).Select(c => new CharacterDto
        {
            Name = c.Name,
            Game = c.Game,
            Role = c.Role,
        }).FirstOrDefaultAsync();
        return result;
    }

    public Task<CharacterDto> CreateCharacterAsinc(CharacterDto character)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCharacterAsinc(int characterId, CharacterDto character)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCharacterAsinc(int characterId)
    {
        throw new NotImplementedException();
    }
}