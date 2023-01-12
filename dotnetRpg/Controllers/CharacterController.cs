using dotnetRpg.Dtos.Character;
using dotnetRpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnetRpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok( await _characterService.GetAllCharacter());
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            var response = await _characterService.UpdateCharacter(updateCharacter);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        /*

        [HttpPut("{id}")]
        public ActionResult<List<Character>> ModifyCharacter(Character character, int id)
        {
            var newCharacter = new Character();

            newCharacter.Id = character.Id;   
            newCharacter.Name = character.Name;
            newCharacter.HitPoints = character.HitPoints;
            newCharacter.Strength = character.Strength;
            newCharacter.Defense = character.Defense;
            newCharacter.Intelligence = character.Intelligence; 

            return Ok(characters);
        }
        */
    }
}
