using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Data.Models;
using VideoGameCharacterApi.Data.Dtos;

namespace VideoGameCharacterApi.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class VideoGameCharactersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetAllCharacters()
        {
            var characters = await context.Characters.Select(c => new CharacterDto
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role,
                TypeName = c.Type.Name,
                Color = c.Color.ColorName
            }).ToListAsync();
            return Ok(characters);
        } 
        
        [HttpGet("/byId/{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var result = await context.Characters.Where(c =>  c.Id == id).Select(c => new CharacterDto
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role,
            }).FirstOrDefaultAsync();
            
            return result != null
                ? Ok(new
                    GenericResponse
                    {
                        Data = result,
                        Message = "success"
                    })
                : NotFound(new
                    GenericResponse
                    {
                        Message = "Failed!",
                        Success = false
                    });
        }

        [HttpGet("/byColor/{id:int}/{color:alpha}")]
        public async Task<ActionResult<Character>> GetCharacterByColor([FromQuery] int id, string hany)
        {
            var result = await context.Characters.Where(c =>  c.Id == id).Select(c => new CharacterDto
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role,
            }).FirstOrDefaultAsync();
            
            return result != null
                ? Ok(new
                    GenericResponse
                    {
                        Data = result,
                        Message = "success"
                    })
                : NotFound(new
                    GenericResponse
                    {
                        Message = "Failed!",
                        Success = false
                    });
        }
        
    }
}


public class GenericResponse
{
    public string? Message { get; set; } = string.Empty;
    public object? Data { get; set; }
    public bool Success { get; set; } = true;
}