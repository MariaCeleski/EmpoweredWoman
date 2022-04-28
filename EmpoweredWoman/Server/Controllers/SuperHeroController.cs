using EmpoweredWoman.Server.Data;
using EmpoweredWoman.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpoweredWoman.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _Context;
        public SuperHeroController(DataContext Context)
        {
            _Context = Context;

        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var heroes = await _Context.SuperHeroes.Include(sh => sh.Position).ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("positions")]
        public async Task<ActionResult<List<Position>>> GetPositions()
        {
            var positions = await _Context.Positions.ToListAsync();
            return Ok(positions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _Context.SuperHeroes
                .Include(h => h.Position)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            hero.Position = null;
            _Context.SuperHeroes.Add(hero);
            await _Context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero, int id)
        {
            var dbHero = await _Context.SuperHeroes
                .Include(sh => sh.Position)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbHero == null)
                return NotFound("Sorry, but no hero for you. :/");

            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Country = hero.Country;
            dbHero.Company = hero.Company;
            dbHero.FinancialBank = hero.FinancialBank;
            dbHero.Actions = hero.Actions;
            dbHero.PositionId = hero.PositionId;

            await _Context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var dbHero = await _Context.SuperHeroes
                .Include(sh => sh.Position)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbHero == null)
                return NotFound("Sorry, but no hero for you. :/");

            _Context.SuperHeroes.Remove(dbHero);
            await _Context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        private async Task<List<SuperHero>> GetDbHeroes()
        {
            return await _Context.SuperHeroes.Include(sh => sh.Position).ToListAsync();
        }
    }
}


