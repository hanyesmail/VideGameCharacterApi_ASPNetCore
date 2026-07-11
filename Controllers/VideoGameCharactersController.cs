using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharactersController(IVideoGameCharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters() => 
            Ok(await service.GetAllCharactersAsinc());

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var result = await service.GetCharacterByIdAsinc(id);
            return result != null ? Ok(Task.FromResult(result)) :  NotFound("Character not found");
        }
    }
}
