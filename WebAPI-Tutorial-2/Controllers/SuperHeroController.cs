using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Tutorial_2.Data;
using WebAPI_Tutorial_2.Models;

namespace WebAPI_Tutorial_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        /*START*/
        // This is bad practice - the context should be injected into SuperHeroService or SuperHeroRepository
        //  instead and then the Controller would inject the service or the repository

        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }
        /*END*/

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")] // Combining Action Method with Route
        public async Task<ActionResult<SuperHero>> GetHeroById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if(hero == null)
            {
                return NotFound("Hero not found");
            }
            return Ok(hero);
        }

        /* START */
        // Using model class as parameter is a bad practice, I should create DTO (DataTransferObject) with
        // properties that I actually need in SuperHeroService
        [HttpPost]
        public async Task<ActionResult> AddHero([FromBody]SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok();
        }
        /* END */

        [HttpPut]
        public async Task<ActionResult> UpdateHero([FromBody] SuperHero hero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);

            if (dbHero == null)
            {
                return NotFound("Hero not found");
            }
            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;  // Begins tracking, doesn't do anything until changes are saved

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero([FromRoute]int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);

            if (dbHero == null)
            {
                return NotFound("Hero not found");
            }

            _context.SuperHeroes.Remove(dbHero); // Begins tracking, doesn't do anything until changes are saved

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
