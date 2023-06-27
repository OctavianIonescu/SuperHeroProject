using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroProject.Entity;
using SuperHeroProject.SuperHeroService;

namespace SuperHeroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperheroService _superheroService;
        public SuperHeroController(ISuperheroService superHeroService)
        {
            _superheroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = await _superheroService.GetAllHeroes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHeroes(int id)
        {
            var result = await _superheroService.GetSingleHeroes(id);
            if (result == null)
            {
                return NotFound("Sorry but hero is unavailable");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _superheroService.AddHero(hero);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> EditHero(int id, SuperHero req)
        {
            var hero = await _superheroService.EditHero(id, req);
            if (hero == null)
            {
                return NotFound("Sorry but hero is unavailable");
            }   
            return Ok(hero);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var superHeroes = await _superheroService.DeleteHero(id);
            return Ok(superHeroes);
        }

    }
}
